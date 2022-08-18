using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarDirectionMarkupElement : BaseMarkupElement
    {
        public StarDirectionMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[dir:{0}]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.Direction != TextDirection.Default)
            {
                var newText = string.Format(Template, textDocumentElement.Style.Direction);
                textDocumentElement.Value = $"{newText}{textDocumentElement.Value}";
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


