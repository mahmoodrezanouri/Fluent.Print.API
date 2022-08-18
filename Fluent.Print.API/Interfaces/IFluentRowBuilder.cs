using System;
using System.Collections.Generic;
using System.Text;

namespace Fluent.Print.API
{
    public interface IFluentRowBuilder
    {
        DocumentGridRow PrintRow(Action<DocumentGridRow> row);
    }
    public interface IFluentColumnBuilder
    {
        IFluentColumnBuilder PrintColumn(Action<DocumentGridColumn> row);
        ICollection<DocumentGridColumn> Build();
        FluentColumnBuilder End();
    }
}
