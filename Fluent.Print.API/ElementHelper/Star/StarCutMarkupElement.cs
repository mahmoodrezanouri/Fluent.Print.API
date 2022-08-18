using System.Linq;
using System.Xml.Linq;
using System;

namespace Fluent.Print.API
{
    public class StarCutMarkupElement : BaseMarkupElement
    {
        public StarCutMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = @"[cut]";
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            return $"{Template}";
        }

    }

}


