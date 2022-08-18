using System.Linq;
using System.Xml.Linq;

namespace Fluent.Print.API
{
    public class StarTextMarkupElement : BaseMarkupElement
    {
        public StarTextMarkupElement(int id, string typeName)
            : base(id, typeName, string.Empty)
        {
        }
        public override string CreateElement(IPrintDocumentElement documentElement)
        {
            var textLineDocumentElement = documentElement as TextDocumentElement;

            SetSpace(textLineDocumentElement);
            SetStyle(textLineDocumentElement);

            return textLineDocumentElement.Value;
        }

        public void SetStyle(TextDocumentElement textLineDocumentElement)
        {
            if (string.IsNullOrEmpty(textLineDocumentElement.Value))
            {
                SetAlign(textLineDocumentElement);
                return;
            }

            SetNegative(textLineDocumentElement);
            SetBold(textLineDocumentElement);
            SetFont(textLineDocumentElement);
            SetUnderLine(textLineDocumentElement);
            SetAlign(textLineDocumentElement);
            SetDirection(textLineDocumentElement);
        }

        private void SetSpace(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.Space.CreateElement(textDocumentElement);
        }
        public void SetBold(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.Bold.CreateElement(textDocumentElement);
        }
        public void SetNegative(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.Negative.CreateElement(textDocumentElement);
        }
        public void SetUnderLine(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.UnderLine.CreateElement(textDocumentElement);
        }
        public void SetFont(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.Font.CreateElement(textDocumentElement);
        }
        public void SetAlign(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.Align.CreateElement(textDocumentElement);
        }
        public void SetDirection(TextDocumentElement textDocumentElement)
        {
            StarMarkupElements.Direction.CreateElement(textDocumentElement);
        }

    }

}


