using System;
using System.Collections.Generic;


namespace Fluent.Print.API
{
    public class FluentRowBuilder : IFluentRowBuilder
    {
        
        private ICollection<IPrintDocumentElement> _printDocumentRowElements;
 

        private FluentRowBuilder()
        {
            _printDocumentRowElements = new HashSet<IPrintDocumentElement>();
        }

        public static IFluentRowBuilder Start()
        {
            return new FluentRowBuilder();
        }

        public DocumentGridRow PrintRow(Action<DocumentGridRow> row)
        {
            var newRow = ObjectHelper.SetAction(row);
            _printDocumentRowElements.Add(newRow);

            return newRow;
        }


    }

}
