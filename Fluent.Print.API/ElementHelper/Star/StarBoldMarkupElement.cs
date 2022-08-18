using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarBoldMarkupElement : BaseMarkupElement
    {
        public StarBoldMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[bold: on]{0}[bold: off]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.Bold)
            {
                var newText = string.Format(Template, textDocumentElement.Value);
                textDocumentElement.Value = newText;
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


