using System;
using System.Collections.Generic;
using System.Text;

namespace Fluent.Print.API
{
    public interface IPrintDocumentElementAttribute
    {
    }
    public interface IPrintDocumentCustomTag : IPrintDocumentElement
    {
    }

    public interface IPrintCustomGridTag : IPrintDocumentElement
    {
    }
}
