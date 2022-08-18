using System.Linq;
using System.Xml.Linq;

namespace Fluent.Print.API
{
    public class StarGridMarkupElement : BaseMarkupElement
    {
        public StarGridMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {

        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var output = string.Empty;
            var documenGridElement = documentElement as DocumentGridElement;
            documenGridElement.Header.ColumnSpace = documenGridElement.ColumnSpace;

            output += StarMarkupElements.GridHeader.CreateElement(documenGridElement.Header);

            if (documenGridElement.Sections != null && documenGridElement.Sections.Any())
                foreach (var section in documenGridElement.Sections)
                {
                    section.PaperWidth = documenGridElement.PaperWidth;
                    output += StarMarkupElements.GridSection.CreateElement(section);
                }

            if (documenGridElement.Rows != null && documenGridElement.Rows.Any())
                foreach (var row in documenGridElement.Rows)
                {
                    row.PaperWidth = documenGridElement.PaperWidth;
                    output += StarMarkupElements.GridRow.CreateElement(row);
                }

            return output;
        }

    }

}


