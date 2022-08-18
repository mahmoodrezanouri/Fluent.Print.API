using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarUnderLineMarkupElement : BaseMarkupElement
    {
        public StarUnderLineMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[underline: on] {0} [underline: off]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.UnderLine)
            {
                var newText = string.Format(Template, textDocumentElement.Value);
                textDocumentElement.Value = newText;
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


