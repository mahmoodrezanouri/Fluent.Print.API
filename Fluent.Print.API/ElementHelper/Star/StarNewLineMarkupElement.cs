using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent.Print.API
{
    public class StarNewLineMarkupElement : BaseMarkupElement
    {
        public StarNewLineMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
            base.Template = Environment.NewLine;
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            return $"{Template}";
        }

    }

}


