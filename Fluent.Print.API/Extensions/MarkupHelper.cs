using System;
using System.ComponentModel;
using System.Reflection;

namespace Fluent.Print.API
{
    public static class MarkupHelper
    {
        public static string ToStringMarkup(this IFluentPrintDocumentBuilder document, string printerName, string layoutPath)
        {
            var printElements = document.Build();

            foreach (var element in printElements)
            {
                //var el = CreateElement(doc);
                //print.Add(el);
            }
            return null;
        }
    }
}
