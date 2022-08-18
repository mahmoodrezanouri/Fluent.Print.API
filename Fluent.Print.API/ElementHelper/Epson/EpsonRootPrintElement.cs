using System.Linq;
using System.Xml.Linq;


namespace Fluent.Print.API
{
    public class EpsonRootPrintElement : BaseMarkupElement
    {
        protected static XNamespace nameSpace;
        private static XNamespace _soap = "http://schemas.xmlsoap.org/soap/envelope/";

        public EpsonRootPrintElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {

        }

        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            //var textLineDocumentElement = (BaseTextLineDocumentElement)documentElement;

            //var textEl = new XElement(nameSpace + TagName);
            //textEl.Add(textLineDocumentElement.Value);

            //if (textLineDocumentElement.Attributes != null && textLineDocumentElement.Attributes.Any())
            //{
            //    foreach (var attr in textLineDocumentElement.Attributes)
            //    {
            //        textEl.Add(new XAttribute(attr.Name, attr.Value));
            //    }
            //}
            //if (textLineDocumentElement.Style != null)
            //{
            //    var propsInfo = textLineDocumentElement.Style.GetProperties();
            //    foreach (var prop in propsInfo)
            //    {
            //        textEl.Add(new XAttribute(prop.Key, prop.Value));
            //    }
            //}
            return default;
        }
        public XElement CreateXmlElement(IPrintDocumentElement documentElement)
        {
            return default(XElement);
        }
        public XElement GetRootPrintElement()
        {
            return default(XElement);
        }
        public XElement GetEnvelopeElement()
        {
            return new XElement(_soap + "Envelope");
        }
        public XElement GetBodyElement()
        {
            return new XElement(_soap + "Body");
        }
        public XNamespace GetNameSpace()
        {
            return nameSpace;
        }
        public XElement CreateXmlRequest(IFluentPrintDocumentBuilder document)
        {
            var envelope = GetEnvelopeElement();
            var body = GetBodyElement();
            var print = GetRootPrintElement();

            envelope.Add(body);
            body.Add(print);

            var printDocuments = document.Build();

            foreach (var doc in printDocuments)
            {
                var el = CreateElement(doc);
                print.Add(el);
            }

            return envelope;
        }


    }

}


