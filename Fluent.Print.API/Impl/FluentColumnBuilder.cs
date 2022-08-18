
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fluent.Print.API
{
    public class FluentColumnBuilder : IFluentColumnBuilder
    {
        
       private ICollection<DocumentGridColumn> _printDocumentColumnElements;
 

        private FluentColumnBuilder()
        {
            _printDocumentColumnElements = new HashSet<DocumentGridColumn>();
        }

        public static IFluentColumnBuilder Start()
        {
            return new FluentColumnBuilder();
        }

        public IFluentColumnBuilder PrintColumn(Action<DocumentGridColumn> column)
        {
            var newColumn = ObjectHelper.SetAction(column);
            _printDocumentColumnElements.Add(newColumn);

             return this;
        }

        public ICollection<DocumentGridColumn> Build()
        {
            return _printDocumentColumnElements;
        }

        public FluentColumnBuilder End()
        {
            return this;
        }


    }

}
