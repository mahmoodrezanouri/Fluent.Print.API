using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fluent.Print.API
{
    public interface IFluentPrintDocumentBuilder
    {
        IFluentPrintDocumentBuilder PrintLine(Action<TextDocumentElement> text);
        IFluentPrintDocumentBuilder SetStyle(Action<TextStyle> style);
        IFluentPrintDocumentBuilder SetAttribute(Action<TextAttribute> attribute);
        IFluentPrintDocumentBuilder PrintGrid(Action<DocumentGridElement> grid);
        IFluentPrintDocumentBuilder PrintMultipleElement(Action<DocumentMultiplelement> element);
        IFluentPrintDocumentBuilder SetCustomTag(Action<CustomDocumentTag> tag);
        IFluentPrintDocumentBuilder PrintNewLine();
        IFluentPrintDocumentBuilder Cut();
        IFluentPrintDocumentBuilder PrintHorizontalLine(Action<HorizontalLineDocumentElement> line);
        IFluentPrintDocumentBuilder PrintImage(string text);
        ICollection<IPrintDocumentElement> Build();
        ICollection<IPrintDocumentElement> Build(int paperWidth);
    }

}
