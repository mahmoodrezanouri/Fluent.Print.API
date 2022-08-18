using System.Linq;
using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace Fluent.Print.API
{
    public class StarGridSectionMarkupElement : BaseMarkupElement
    {
        public StarGridSectionMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var output = string.Empty;
            var sectionElement = documentElement as DocumentGridSection;


            if (!string.IsNullOrEmpty(sectionElement.Title))
            {
                var el = new TextDocumentElement()
                {
                    Value = sectionElement.Title,
                    Style = new TextStyle() { Align = TextAlign.Left, Bold = true }
                };

                output += StarMarkupElements.Text.CreateElement(el);

                var underlineEl = new TextDocumentElement()
                {
                    Value = $@"\{Environment.NewLine}-----------------------------------",
                    Style = new TextStyle() { Align = TextAlign.Middle }
                };
                output += (Environment.NewLine + StarMarkupElements.Text.CreateElement(underlineEl));
                output += Environment.NewLine;
            }

            var preRowHasLargFont = false;
            var rows = sectionElement.Rows.ToList();

            foreach (var row in rows)
            {
                FixIndetion(rows, row, ref preRowHasLargFont);
                output += StarMarkupElements.GridRow.CreateElement(row);
            }

            return output;

        }

        private void FixIndetion(ICollection<DocumentGridRow> rows, DocumentGridRow row,ref bool preRowHasLargFont)
        {
            //Fix extra indention issues
            if (rows.First() == row || (preRowHasLargFont && row.Columns.FirstOrDefault().Content?.Style?.FontSize !=  FontSize.Large))
                row.ColumnSpace--;

            preRowHasLargFont = row.Columns.LastOrDefault().Content?.Style?.FontSize == FontSize.Large;
        }

    }

}


