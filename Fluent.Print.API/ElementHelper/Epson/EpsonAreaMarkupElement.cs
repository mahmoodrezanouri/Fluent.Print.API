using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonAreaMarkupElement : BaseMarkupElement
    {
        public EpsonAreaMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {
            base.Template = @"<cut />";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {

            return Template;
        }

    }

}


