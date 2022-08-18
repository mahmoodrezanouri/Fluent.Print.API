using System;
using System.Collections.Generic;
using System.Text;

namespace Fluent.Print.API
{
    public interface IPrintDocumentElement
    {
        string TemplateSection { get; set; }
        bool Visible { get; set; }
        int PaperWidth { get; set; }
    }
}
