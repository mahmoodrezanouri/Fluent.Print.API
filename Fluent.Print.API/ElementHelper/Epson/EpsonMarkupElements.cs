using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Fluent.Print.API
{
    public class EpsonMarkupElements : BaseMarkupElement
    {
        public static XNamespace EnvelopeNameSpace => "http://schemas.xmlsoap.org/soap/envelope/";
        public static XNamespace NameSpace => "http://www.epson-pos.com/schemas/2011/03/epos-print";
        public static string EposPrintElementTag => "epos-print";
        public static string EnvelopeElementTag => "Envelope";
        public static string BodyElementTag => "Body";
        public static string HeaderTag => "Header";
        public static string ParameterTag => "parameter";
        public static string DevIDTag => "devid";
        public static string TimeoutTag => "timeout";
        public static string PrintJobIDTag => "printjobid";
        public static string DeviceID => "local_printer";
        public static string Timeout => "60000";

        public static EpsonRootPrintElement RootPrintElement = new EpsonRootPrintElement(0, nameof(RootPrintElement).ToLowerInvariant(), string.Empty);
        public static EpsonTextMarkupElement Text = new EpsonTextMarkupElement(1, typeof(TextDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonImageMarkupElement Image = new EpsonImageMarkupElement(2, typeof(ImageDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonNewLineMarkupElement NewLine = new EpsonNewLineMarkupElement(3, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonSpaceMarkupElement Space = new EpsonSpaceMarkupElement(3, typeof(EpsonSpaceMarkupElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonAlignMarkupElement Align = new EpsonAlignMarkupElement(2, typeof(EpsonAlignMarkupElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonUnderLineMarkupElement UnderLine = new EpsonUnderLineMarkupElement(2, typeof(EpsonUnderLineMarkupElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonDirectionMarkupElement Direction = new EpsonDirectionMarkupElement(4, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonBarCodeMarkupElement BarCode = new EpsonBarCodeMarkupElement(5, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonBoldMarkupElement Bold = new EpsonBoldMarkupElement(6, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonColumnMarkupElement Column = new EpsonColumnMarkupElement(7, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonCommentMarkupElement Comment = new EpsonCommentMarkupElement(8, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonPageMarkupElement Page = new EpsonPageMarkupElement(9, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonCutMarkupElement Cut = new EpsonCutMarkupElement(10, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonFeedMarkupElement Feed = new EpsonFeedMarkupElement(11, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonFontMarkupElement Font = new EpsonFontMarkupElement(12, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonLogoMarkupElement Logo = new EpsonLogoMarkupElement(13, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonSymbolMarkupElement Symbol = new EpsonSymbolMarkupElement(14, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonAreaMarkupElement Area = new EpsonAreaMarkupElement(15, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonHlineMarkupElement Hline = new EpsonHlineMarkupElement(17, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonVlineBeginMarkupElement VlineBegin = new EpsonVlineBeginMarkupElement(18, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonVlineEndMarkupElement VlineEnd = new EpsonVlineEndMarkupElement(19, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonSoundMarkupElement Sound = new EpsonSoundMarkupElement(20, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonPulseMarkupElement Pulse = new EpsonPulseMarkupElement(21, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonLineMarkupElement Line = new EpsonLineMarkupElement(22, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonMarkupElements Position = new EpsonMarkupElements(23, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonRectangleMarkupElement Rectangle = new EpsonRectangleMarkupElement(24, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonRecoveryMarkupElement Recovery = new EpsonRecoveryMarkupElement(25, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);
        public static EpsonResetMarkupElement Reset = new EpsonResetMarkupElement(26, typeof(NewLineDocumentElement).Name.ToLowerInvariant(), string.Empty);

        public EpsonMarkupElements(int id, string typeName, string tagName)
           : base(id, typeName, tagName)
        {

        }

        public static IEnumerable<BaseMarkupElement> List()
        {
            var list = new BaseMarkupElement[] {

               RootPrintElement,
               Text,
               Image,
               NewLine
           };

            return list;

        }
        public static BaseMarkupElement FromTypeName(string typeName)
        {
            var el = List().SingleOrDefault(s => string.Equals(s.Name, typeName, StringComparison.CurrentCultureIgnoreCase));

            //if (el == null)
            //{
            //    throw new ArgumentException($"Possible values for EpsonPrintElement : {string.Join(",", List().Select(s => s.Name))}");
            //}

            return el;
        }
        public override XElement CreateXElement(IPrintDocumentElement documentElement)
        {
            var el = FromTypeName(documentElement.GetType().Name.ToLowerInvariant());

            if (el != default)
                return el.CreateXElement(documentElement);

            return default;
        }
        private XElement GetEnvelopeElement()
        {
            return new XElement(EnvelopeNameSpace + EnvelopeElementTag);
        }
        private XElement GetHeadElement(string printJobID)
        {
            var headEl = new XElement(HeaderTag);
            var parameterEl = CreateXElementWithTagName(ParameterTag, addNameSpace: true);

            var devIDEl = CreateXElementWithTagName(DevIDTag, value: DeviceID);
            var timeoutEl = CreateXElementWithTagName(TimeoutTag, value: Timeout);
            var printJobIDEl = CreateXElementWithTagName(PrintJobIDTag, value: printJobID);

            parameterEl.Add(devIDEl);
            parameterEl.Add(timeoutEl);
            parameterEl.Add(printJobIDEl);

            headEl.Add(parameterEl);
            return headEl;
        }
        private XElement GetBodyElement()
        {
            return new XElement(EnvelopeNameSpace + BodyElementTag);
        }
        private XElement CreateXElementWithTagName(string tagName, string value = default, bool addNameSpace = false)
        {
            var nameSpace = addNameSpace ? NameSpace : string.Empty;
            var newEl = new XElement(nameSpace + tagName);

            if (value != default)
                newEl.Value = value;

            return newEl;
        }

        public override string BuildPrintDocument(IFluentPrintDocumentBuilder fluentPrintDocument)
        {
            var printDoc = fluentPrintDocument.Build();

            var envelopeEl = GetEnvelopeElement();
            var headEl = GetHeadElement("ABCD1234");
            var bodyEl = GetBodyElement();
            var eposPrintEl = CreateXElementWithTagName(EposPrintElementTag, addNameSpace:true);

            envelopeEl.Add(headEl);
            envelopeEl.Add(bodyEl);
            bodyEl.Add(eposPrintEl);

            foreach (var doc in printDoc)
            {
                if (!doc.Visible)
                {
                    continue;
                }
                var el = CreateXElement(doc);
                if (el != default)
                    eposPrintEl.Add(el);
            }

            return envelopeEl.ToString();
        }

    }
}
