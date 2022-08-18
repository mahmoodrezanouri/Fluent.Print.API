using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarSpaceMarkupElement : BaseMarkupElement
    {
        public StarSpaceMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[sp: c {0}]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Space != null)
            {
                textDocumentElement.Space.PaperWidth = documentElement.PaperWidth;

                var newText = string.Format(Template, textDocumentElement.Space.Count);
                textDocumentElement.Value = $"{textDocumentElement.Value}{newText}";
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


