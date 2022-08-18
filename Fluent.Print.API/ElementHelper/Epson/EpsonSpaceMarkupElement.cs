using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonSpaceMarkupElement : BaseMarkupElement
    {
        public EpsonSpaceMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {
            base.Template = @"[sp: c {0}]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Space != null)
            {
                var newText = string.Format(Template, textDocumentElement.Space.Count);
                textDocumentElement.Value = $"{textDocumentElement.Value}{newText}";
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


