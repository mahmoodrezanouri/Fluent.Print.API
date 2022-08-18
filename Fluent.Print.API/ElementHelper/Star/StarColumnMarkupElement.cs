using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class StarColumnMarkupElement : BaseMarkupElement
    {
        public StarColumnMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {

        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            return $"{TagName}";
        }

    }

}


