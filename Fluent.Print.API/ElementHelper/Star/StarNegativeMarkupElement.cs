using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarNegativeMarkupElement : BaseMarkupElement
    {
        public StarNegativeMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[negative: on]{0}[negative: off]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.Negative)
            {
                var newText = string.Format(Template, textDocumentElement.Value);
                textDocumentElement.Value = newText;
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


