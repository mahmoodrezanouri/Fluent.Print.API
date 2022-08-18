using System.Linq;
using System.Xml.Linq;
using System;

namespace Fluent.Print.API
{
    public class StarGridHeaderMarkupElement : BaseMarkupElement
    {
        public StarGridHeaderMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[align: left][font: name a][bold: on][underline: on]{0}[underline: off][bold: off]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {

            if (documentElement.Visible == false)
                return default;

            var output = string.Empty;
            var headerElement = documentElement as DocumentGridHeader;

            var totalChars = headerElement.Columns.Select(c => (c.Content?.Value != null ? c.Content.Value.Length : 0)
                                                              + (c.Content?.Space != null ? c.Content.Space.Count : 0));

            var remainigSpaces = PaperWidthBaseAFontCharCount - totalChars.Sum(x => x);

            foreach (var col in headerElement.Columns)
            {
                //if (col.Content.Space == null && col != headerElement.Columns.Last())
                //    col.Content.Space = new Space() { Count = 2 };
                var strCol = StarMarkupElements.GridColumn.CreateElement(col);
                
                if (col.Content?.Style?.Direction == TextDirection.Right)
                {
                    strCol = strCol.Replace("[dir:Right]", $"[sp: c {remainigSpaces}]");
                }
                output += strCol;

            }

            var fillRowSpace = string.Empty;

            if (remainigSpaces > 0)
            {
                fillRowSpace = string.Format("[sp: c {0}]", remainigSpaces);
            }

            if (headerElement.Columns.All(c => string.IsNullOrEmpty(c.Content.Value)))
            {
                var template = Template.Replace("[align: left]", "[align: middle]");
                output = string.Format(template, output, string.Empty) + Environment.NewLine;
            }
            else
            {
                output = string.Format(Template, output, fillRowSpace) + Environment.NewLine;
            }


            return output;
        }

    }

}


