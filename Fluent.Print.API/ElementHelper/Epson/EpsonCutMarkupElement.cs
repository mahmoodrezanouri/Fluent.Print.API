using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonCutMarkupElement : BaseMarkupElement
    {
        public EpsonCutMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {

        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            return default;
        }
        public XAttribute GetXElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;
            var fontSize = GetFontSize(textDocumentElement.Style?.FontSize);

            if (textDocumentElement.Style != null && !string.IsNullOrEmpty(fontSize))
            {
                return new XAttribute(Template, fontSize);
            }

            return default;
        }
        private string GetFontSize(FontSize? fontSize)
        {
            if (fontSize == FontSize.Large)
                return "a";
            if (fontSize == FontSize.Small)
                return "b";

            return string.Empty;
        }

    }

}


