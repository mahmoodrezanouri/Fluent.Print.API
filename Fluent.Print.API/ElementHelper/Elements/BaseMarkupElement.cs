using System.Xml.Linq;
using System.Collections.Generic;

namespace Fluent.Print.API
{ 
    public class BaseMarkupElement : Enumeration
    {
        public const int PaperWidthBaseAFontCharCount = 46;
        public string TagName { get; set; }

        public string Template { get; set; }

        public BaseMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName)
        {
            TagName = tagName;
        }
        public virtual string CreateElement(IPrintDocumentElement documentElement)
        {
            return default;
        }
        public virtual XElement CreateXElement(IPrintDocumentElement documentElement)
        {
            return default;
        }
        public virtual XAttribute CreateXAttribute(IPrintDocumentElement documentElement)
        {
            return default;
        }
        public virtual string BuildPrintDocument(IFluentPrintDocumentBuilder fluentPrintDocument)
        {
            return default;
        }
        public virtual string BuildPrintDocument(IEnumerable<IFluentPrintDocumentBuilder> fluentPrintDocuments)
        {
            return default;
        }
        

    }

}


