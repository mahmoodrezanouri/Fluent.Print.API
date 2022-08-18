using System.Linq;
using System.Xml.Linq;

namespace Fluent.Print.API
{
    public class EpsonTextMarkupElement : BaseMarkupElement
    {
        private XElement _textEl; 
        public EpsonTextMarkupElement(int id, string typeName, string tagName)
            : base(id, typeName, tagName)
        {
            base.Template = @"text";
        }
        public override XElement CreateXElement(IPrintDocumentElement documentElement)
        {
            var textLineDocumentElement = documentElement as TextDocumentElement;

            _textEl = new XElement(Template);

            SetSpace(textLineDocumentElement);
            SetStyle(textLineDocumentElement);

            _textEl.Value = textLineDocumentElement.Value;

            return _textEl;
        }

        public void SetStyle(TextDocumentElement textLineDocumentElement)
        {
            SetBold(textLineDocumentElement);
            SetFont(textLineDocumentElement);
            SetUnderLine(textLineDocumentElement);
            SetAlign(textLineDocumentElement);
        }

        private void SetSpace(TextDocumentElement textDocumentElement)
        {
           var attr = EpsonMarkupElements.Space.CreateElement(textDocumentElement);
        }
        private void SetBold(TextDocumentElement textDocumentElement)
        {
            var attr = EpsonMarkupElements.Bold.CreateXAttribute(textDocumentElement);
            _textEl.Add(attr);
        }
        private void SetUnderLine(TextDocumentElement textDocumentElement)
        {
            var attr = EpsonMarkupElements.UnderLine.CreateXAttribute(textDocumentElement);
            _textEl.Add(attr);
        }
        private void SetFont(TextDocumentElement textDocumentElement)
        {
            var attr = EpsonMarkupElements.Font.CreateXAttribute(textDocumentElement);
            _textEl.Add(attr);
        }
        private void SetAlign(TextDocumentElement textDocumentElement)
        {
            var attr = EpsonMarkupElements.Align.CreateXAttribute(textDocumentElement);
            _textEl.Add(attr);
        }

    }

}


