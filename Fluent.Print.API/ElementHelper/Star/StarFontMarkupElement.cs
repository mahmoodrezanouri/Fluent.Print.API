using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarFontMarkupElement : BaseMarkupElement
    {
        public StarFontMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
           base.Template = @"[font: name {0}]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;
            var fontSize = GetFontSize(textDocumentElement.Style?.FontSize);

            if (textDocumentElement.Style != null && !string.IsNullOrEmpty(fontSize))
            {
                var newText = string.Format(Template, fontSize);
                textDocumentElement.Value = $"{newText}{textDocumentElement.Value}";
                return newText;
            }

            return textDocumentElement.Value;
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


