using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarAlignMarkupElement : BaseMarkupElement
    {
        public StarAlignMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[align:{0}]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as TextDocumentElement;

            if (textDocumentElement.Style != null && textDocumentElement.Style.Align != TextAlign.Default)
            {
                var newText = string.Format(Template, textDocumentElement.Style.Align);
                textDocumentElement.Value = $"{newText}{textDocumentElement.Value}";
                return newText;
            }

            return textDocumentElement.Value;
        }

    }

}


