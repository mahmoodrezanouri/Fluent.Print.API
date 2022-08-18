using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarHorizontalLineMarkupElement : BaseMarkupElement
    {
        public StarHorizontalLineMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[underline: on][sp: c {0}][underline: off]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textDocumentElement = documentElement as HorizontalLineDocumentElement;

            var el = string.Format(Template, textDocumentElement.Length + 2);
         
            return el;

        }

    }

}


