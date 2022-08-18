using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarLogoMarkupElement : BaseMarkupElement
    {
        public StarLogoMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {

        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            return $"{TagName}";
        }

    }

}


