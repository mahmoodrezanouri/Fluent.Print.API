using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonAlignMarkupElement : BaseMarkupElement
    {
        public EpsonAlignMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {
            base.Template = @"align";
        }

        public override XAttribute CreateXAttribute(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.Align != TextAlign.Default)
            {
                return new XAttribute(Template, textDocumentElement.Style.Align);
            }

            return default;
        }

    }

}


