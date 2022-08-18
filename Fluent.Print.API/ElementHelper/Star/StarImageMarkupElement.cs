
namespace Fluent.Print.API
{
    public class StarImageMarkupElement : BaseMarkupElement
    {
        public StarImageMarkupElement(int id, string typeName)
            : base(id, typeName , string.Empty)
        {
            base.Template = $"[]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var element = (ImageDocumentElement)documentElement;
            return $"[image: url {element.Value}]";
        }

    }

}


