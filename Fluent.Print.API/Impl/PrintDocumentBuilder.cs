using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Fluent.Print.API
{
    public class PrintDocumentBuilder : IFluentPrintDocumentBuilder
    {
        [JsonProperty]
        private ICollection<IPrintDocumentElement> _printDocumentElements;
        
        public Printer Printer { get; set; }
        public Template Template { get; set; }
        public PrintConfig PrintConfig { get; set; }

        private PrintDocumentBuilder()
        {
            _printDocumentElements = new HashSet<IPrintDocumentElement>();
        }

        public static IFluentPrintDocumentBuilder Start()
        {
            return new PrintDocumentBuilder();
        }

        public IFluentPrintDocumentBuilder ForPrinter(Action<Printer> printer)
        {
            Printer = ObjectHelper.SetAction(printer);
            return this;
        }

        public IFluentPrintDocumentBuilder WithTemplate(Action<Template> template)
        {
            Template = ObjectHelper.SetAction(template);
            return this;
        }

        public IFluentPrintDocumentBuilder WithConfig(Action<PrintConfig> config)
        {
            PrintConfig = ObjectHelper.SetAction(config);
            return this;
        }

        public IFluentPrintDocumentBuilder PrintImage(string imageUrl)
        {
            _printDocumentElements.Add(new ImageDocumentElement() { Value = imageUrl });
            return this;
        }

        public IFluentPrintDocumentBuilder PrintLine(Action<TextDocumentElement> text)
        {
            var newtext = ObjectHelper.SetAction(text);
            _printDocumentElements.Add(newtext);

            return this;

        }

        public IFluentPrintDocumentBuilder SetCustomTag(Action<CustomDocumentTag> tag)
        {
            var newTag = ObjectHelper.SetAction(tag);
            _printDocumentElements.Add(newTag);

            return this;
        }

        public IFluentPrintDocumentBuilder PrintGrid(Action<DocumentGridElement> grid)
        {
            var newGrid = ObjectHelper.SetAction(grid);
            _printDocumentElements.Add(newGrid);

            return this;
        }

        public IFluentPrintDocumentBuilder PrintMultipleElement(Action<DocumentMultiplelement> element)
        {
            var newElement = ObjectHelper.SetAction(element);
            _printDocumentElements.AddRange(newElement.Elements);
            return this;
        }

        public IFluentPrintDocumentBuilder SetAttribute(Action<TextAttribute> attribute)
        {
            var newtextAttribute = ObjectHelper.SetAction(attribute);

            var textLineEl = GetLastTextLineElement();

            if (textLineEl != null)
            {
                var attrList = textLineEl.Attributes.ToList();
                attrList.Add(newtextAttribute);
                textLineEl.Attributes = attrList;
            }

            return this;
        }
        public IFluentPrintDocumentBuilder SetStyle(Action<TextStyle> style)
        {
            var newStyle = ObjectHelper.SetAction(style);
            var textLineEl = GetLastTextLineElement();

            if (textLineEl != null)
            {
                textLineEl.Style = newStyle;
            }

            return this;
        }

        public IFluentPrintDocumentBuilder PrintNewLine()
        {
            _printDocumentElements.Add(new NewLineDocumentElement());
            return this;
        }
        public IFluentPrintDocumentBuilder Cut()
        {
            _printDocumentElements.Add(new CutDocumentElement());
            return this;
        }


        public IFluentPrintDocumentBuilder PrintHorizontalLine(Action<HorizontalLineDocumentElement> line)
        {
            var newLine = ObjectHelper.SetAction(line);
            _printDocumentElements.Add(newLine);
            return this;
        }

        public ICollection<IPrintDocumentElement> Build()
        {
            return _printDocumentElements;
        }
        public ICollection<IPrintDocumentElement> Build(int paperWidth)
        {
            _printDocumentElements.ForEach(e => e.PaperWidth = paperWidth);
            return _printDocumentElements;
        }
        private TextDocumentElement GetLastTextLineElement()
        {
            if (_printDocumentElements == null
                || (_printDocumentElements != null && !_printDocumentElements.Any())
                || (_printDocumentElements != null && !_printDocumentElements.Any(x => x.GetType() == typeof(TextDocumentElement)))
                )
            {
                return null;
            }

            return _printDocumentElements.LastOrDefault(x => x.GetType() == typeof(TextDocumentElement)) as TextDocumentElement;
        }


    }

}
