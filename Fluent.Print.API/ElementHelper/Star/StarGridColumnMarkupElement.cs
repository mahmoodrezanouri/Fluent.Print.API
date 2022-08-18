using System.Linq;
using System.Xml.Linq;

namespace Fluent.Print.API
{
    public class StarGridColumnMarkupElement : BaseMarkupElement
    {
        public StarGridColumnMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var documenGridColumnElement = documentElement as DocumentGridColumn;

            documenGridColumnElement.Content.PaperWidth = documenGridColumnElement.PaperWidth;

            var emptyContent = string.IsNullOrEmpty(documenGridColumnElement.Content.Value);
            

            StarMarkupElements.Space.CreateElement(documenGridColumnElement.Content);

            if (!emptyContent)
                StarMarkupElements.Text.SetStyle(documenGridColumnElement.Content);
            else
                StarMarkupElements.Text.SetAlign(documenGridColumnElement.Content);

            return documenGridColumnElement.Content.Value;
        }

    }

}


