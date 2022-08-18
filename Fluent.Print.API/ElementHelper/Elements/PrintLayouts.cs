using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent.Print.API
{
    public class PrintLayouts : Enumeration
    {
        public static PrintLayouts SendToKitchen = new PrintLayouts(1, "SendToKitchen");
        public static PrintLayouts FireCourse = new PrintLayouts(2, "FireCourse");
        public static PrintLayouts DeleteFAndBOrder = new PrintLayouts(3, "DeleteFBOrder");
        public static PrintLayouts FAndBPrintCheck = new PrintLayouts(4, "FB_PrintCheck");
        public static PrintLayouts RetailPrintReceipt = new PrintLayouts(5, "Retail_PrintReceipt");

        public PrintLayouts(int id, string name)
           : base(id, name)
        {
          
        }

        public static IEnumerable<PrintLayouts> List()
        {
            var list = new[] {

               SendToKitchen,
               FireCourse,
               DeleteFAndBOrder,
               FAndBPrintCheck,
               RetailPrintReceipt
           };

            return list;
        }
        public static PrintLayouts FromName(string name)
        {
            var element = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (element == null)
            {
                throw new ArgumentException($"Possible values for PrintLayouts : {string.Join(",", List().Select(s => s.Name))}");
            }

            return element;
        }

    }
}
