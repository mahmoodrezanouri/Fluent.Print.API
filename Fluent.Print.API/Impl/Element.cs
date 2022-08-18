using System;
using System.Collections.Generic;
using System.Linq;


namespace Fluent.Print.API
{
    public class TextStyle : IPrintDocumentElementAttribute
    {
        public string Width { get; set; }
        public string Height { get; set; }
        public TextAlign Align { get; set; }
        public TextDirection Direction { get; set; }
        public bool Bold { get; set; }
        public bool Negative { get; set; }
        public bool UpperLine { get; set; }
        public bool UnderLine { get; set; }
        public FontSize FontSize { get; set; }
        public string Magnify { get; set; }
        public int Indent { get; set; }

    }
    public class PrintConfig
    {
        public bool OpenCachDrawer { get; set; }
    }
    public class TextAttribute : IPrintDocumentElementAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Printer
    {
        public int? PrinterID { get; set; }
        public string Name { get; set; }
    }

    public class DocumentMultiplelement
    {
        public ICollection<IPrintDocumentElement> Elements { get; set; }
        public DocumentGridElement PrintGrid(Action<DocumentGridElement> grid)
        {
            var newGrid = ObjectHelper.SetAction(grid);
            if (Elements == null)
                Elements = new List<IPrintDocumentElement>();

            Elements.Add(newGrid);
            return newGrid;
        }
    }

    public class DocumentGridElement : IPrintDocumentElement
    {
        public DocumentGridElement()
        {
            Rows = new HashSet<DocumentGridRow>();
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string TemplateSection { get; set; }
        public ICollection<DocumentGridRow> Rows { get; set; }
        public ICollection<DocumentGridSection> Sections { get; set; }

        public DocumentGridHeader Header { get; set; }
        public int ColumnSpace { get; set; }
        public DocumentGridElement WithHeader(Action<DocumentGridHeader> header)
        {
            var newHeader = ObjectHelper.SetAction(header);
            newHeader.ColumnSpace = ColumnSpace;

            foreach (var col in newHeader.Columns)
            {
                if (col.Content.Space == null && col != newHeader.Columns.Last())
                    col.Content.Space = new Space() { Size = ColumnSpace.ToString() };
            }

            Header = newHeader;
            return this;
        }
        public DocumentGridSection AddSection(Action<DocumentGridSection> section)
        {
            var newSection = ObjectHelper.SetAction(section);
            newSection.ColumnSpace = ColumnSpace;

            return newSection;
        }

        public DocumentGridRow AddRow(Action<DocumentGridRow> row)
        {
            var newRow = ObjectHelper.SetAction(row);
            newRow.ColumnSpace = ColumnSpace;
            Rows.Add(newRow);
            return newRow;
        }
    }

    public class DocumentGridColumn : IPrintDocumentElement
    {
        public DocumentGridColumn()
        {
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public string Name { get; set; }
        public TextDocumentElement Content { get; set; }
        public string TemplateSection { get; set; }
        public bool Visible { get; set; }
        public DocumentGridColumn SetContent(Action<TextDocumentElement> content)
        {
            var newContent = ObjectHelper.SetAction(content);
            Content = newContent;
            return this;
        }

    }

    public class DocumentGridRow : IPrintDocumentElement
    {
        public DocumentGridRow()
        {
            Columns = new List<DocumentGridColumn>();
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string TemplateSection { get; set; }
        public int ColumnSpace { get; set; }
        public List<DocumentGridColumn> Columns { get; set; }
        public DocumentGridRow Bound(Action<DocumentGridColumn> column)
        {
            var newColumn = ObjectHelper.SetAction(column);

            Columns.Add(newColumn);

            if (Columns.Any() && Columns.Count > 1)
            {
                var lastCol = Columns.Last();
                var indexOfPre = Columns.IndexOf(lastCol) - 1;
                var preCol = Columns[indexOfPre];

                if (preCol.Content != null && preCol.Content.Space == null)
                    preCol.Content.SetSpace(s => s.Size = ColumnSpace.ToString());
            }

            return this;
        }
    }
    public class DocumentGridHeader : IPrintDocumentElement
    {
        public DocumentGridHeader()
        {
            Columns = new List<DocumentGridColumn>();
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }

        public string TemplateSection { get; set; }
        public int ColumnSpace { get; set; }
        public List<DocumentGridColumn> Columns { get; set; }
        public DocumentGridHeader Column(Action<DocumentGridColumn> column)
        {
            var newColumn = ObjectHelper.SetAction(column);
            Columns.Add(newColumn);

            return this;
        }
    }
    public class DocumentGridSection : IPrintDocumentElement
    {
        public DocumentGridSection()
        {
            Rows = new HashSet<DocumentGridRow>();
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string TemplateSection { get; set; }
        public string Title { get; set; }
        public ICollection<DocumentGridRow> Rows { get; set; }
        public int ColumnSpace { get; set; }

        public DocumentGridRow AddRow(Action<DocumentGridRow> row)
        {
            var newRow = ObjectHelper.SetAction(row);
            newRow.ColumnSpace = ColumnSpace;

            Rows.Add(newRow);

            return newRow;
        }
    }
    public class Space : IPrintDocumentElement
    {

        public Space()
        {
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public int Count
        {
            get
            {
                if (string.IsNullOrEmpty(Size))
                    return 0;

                if (Size.Contains("%"))
                {
                    var strPSize = Size.Replace("%", string.Empty);
                    var pSize = int.Parse(strPSize);
                    return (pSize * PaperWidth) / 100;
                }
                else
                {
                    var size = int.Parse(Size);
                    return size;
                }

            }
        }
        public string Size { get; set; }
        public string TemplateSection { get; set; }

    }

    public enum TextAlign : sbyte
    {
        Default = 0,
        Left = 1,
        Right = 2,
        Middle = 3
    }
    public enum TextDirection : sbyte
    {
        Default = 0,
        Left = 1,
        Right = 2
    }
    public enum FontSize : sbyte
    {
        Default = 0,
        Small = 1,
        Large = 2,
    }
    public class CustomGridTag : IPrintCustomGridTag
    {
        public CustomGridTag()
        {
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }
        //public dynamic Value { get; set; }
        public string Value { get; set; }
        public string TemplateSection { get; set; }
    }

    public class Template
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public decimal Version { get; set; }
    }
    public class CustomDocumentTag : IPrintDocumentCustomTag
    {
        public CustomDocumentTag()
        {
            Visible = true;
        }

        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }
        public dynamic Value { get; set; }
        public string TemplateSection { get; set; }
    }

    public class GridTagColumn
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }
    }

    public class HorizontalLineDocumentElement : IPrintDocumentElement
    {
        public int PaperWidth { get; set; }
        public HorizontalLineDocumentElement()
        {
            Visible = true;
        }
        public bool Visible { get; set; }
        public string TemplateSection { get; set; }
        public int Length
        {
            get
            {
                if (string.IsNullOrEmpty(Size))
                    return 0;

                if (Size.Contains("%"))
                {
                    var strPSize = Size.Replace("%", string.Empty);
                    var pSize = int.Parse(strPSize);
                    return (pSize * PaperWidth) / 100;
                }
                else
                {
                    var size = int.Parse(Size);
                    return size;
                }

            }
        }
        public string Size { get; set; }
        public void SetPaperWidth(int width)
        {
            PaperWidth = width;
        }
    }
    public class TextDocumentElement : IPrintDocumentElement
    {
        public TextDocumentElement()
        {
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string Value { get; set; }
        public string TemplateSection { get; set; }
        public IEnumerable<TextAttribute> Attributes { get; set; }
        public TextStyle Style { get; set; }
        public Space Space { get; set; }


        public TextDocumentElement SetStyle(Action<TextStyle> style)
        {
            var newStyle = ObjectHelper.SetAction(style);
            Style = newStyle;

            return this;
        }
        public TextDocumentElement SetSpace(Action<Space> space)
        {
            var newSpace = ObjectHelper.SetAction(space);
            Space = newSpace;

            return this;
        }

    }
    public class ImageDocumentElement : IPrintDocumentElement
    {
        public ImageDocumentElement()
        {
            Visible = true;
        }

        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string Value { get; set; }
        public string TemplateSection { get; set; }
    }
    public class NewLineDocumentElement : IPrintDocumentElement
    {
        public NewLineDocumentElement()
        {
            Visible = true;
        }
        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string TemplateSection { get; set; }
    }
    public class CutDocumentElement : IPrintDocumentElement
    {
        public CutDocumentElement()
        {
            Visible = true;
        }

        public int PaperWidth { get; set; }
        public bool Visible { get; set; }
        public string TemplateSection { get; set; }
    }
}
