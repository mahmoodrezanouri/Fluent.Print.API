using System.Linq;
using System.Xml.Linq;
using System;

namespace Fluent.Print.API
{
    public class StarGridRowMarkupElement : BaseMarkupElement
    {
        public StarGridRowMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var output = string.Empty;
            var documentGridRowElement = documentElement as DocumentGridRow;
            var totalChars = documentGridRowElement.Columns.Select(c => (c.Content?.Value != null ? c.Content.Value.Length : 0)
                                                            + (c.Content?.Space != null ? c.Content.Space.Count : 0));

            var remainigSpaces = PaperWidthBaseAFontCharCount - totalChars.Sum(x => x);

            foreach (var col in documentGridRowElement.Columns)
            {
                col.PaperWidth = documentGridRowElement.PaperWidth;
                var fixSpace = 0;

                if (col == documentGridRowElement.Columns.First() && !string.IsNullOrEmpty(col.Content.Value))
                    fixSpace = col.Content.Value.Length - 1;

                var nextCol = documentGridRowElement.Columns.SkipWhile(c => c != col).Skip(1).FirstOrDefault();
                var indent = nextCol?.Content?.Style != null ? nextCol.Content.Style.Indent : default;

                if (col != documentGridRowElement.Columns.Last())
                {
                    if (col.Content?.Style?.Align == TextAlign.Right && nextCol.Content?.Style?.Align == TextAlign.Right)
                    {
                        fixSpace = nextCol.Content.Value.Length - 1;
                        col.Content.Space = new Space(){};
                    }

                    var count = documentGridRowElement.ColumnSpace + indent - fixSpace + 2;
                    if (col.Content?.Space != null && count > 0)
                        col.Content.Space.Size = count.ToString();

                    if (nextCol != documentGridRowElement.Columns.Last())
                        remainigSpaces = remainigSpaces - count;

                }

                if (nextCol !=  null && (nextCol.Content?.Style?.Direction == TextDirection.Right))
                    col.Content.Space = null;

                var strCol = StarMarkupElements.GridColumn.CreateElement(col);

                if (col.Content?.Style?.Direction == TextDirection.Right)
                {
                    strCol = strCol.Replace("[dir:Right]", $"[sp: c {remainigSpaces}]");
                }
                output += strCol;

                if (col == documentGridRowElement.Columns.Last())
                    output += Environment.NewLine;
            }

            return output;
        }

    }

}


