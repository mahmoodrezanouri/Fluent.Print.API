using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonRecoveryMarkupElement : BaseMarkupElement
    {
        public EpsonRecoveryMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {

        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            return default;
        }

    }

}


