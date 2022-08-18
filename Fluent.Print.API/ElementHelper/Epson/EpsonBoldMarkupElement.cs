using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonBoldMarkupElement : BaseMarkupElement
    {
        public EpsonBoldMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {
            base.Template = @"em";
        }
        public override XAttribute CreateXAttribute(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.Bold)
            {
                return new XAttribute(Template, textDocumentElement.Style.Bold);
            }

            return default;
        }

    }

}


