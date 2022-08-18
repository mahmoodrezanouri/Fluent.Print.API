using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonUnderLineMarkupElement : BaseMarkupElement
    {
        public EpsonUnderLineMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {
            base.Template = @"ul";
        }
        public override XAttribute CreateXAttribute(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.UnderLine)
            {
                return new XAttribute(Template, textDocumentElement.Style.UnderLine);
            }

            return default;
        }

    }

}


