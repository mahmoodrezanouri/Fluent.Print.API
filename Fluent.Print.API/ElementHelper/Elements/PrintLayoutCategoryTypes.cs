using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent.Print.API
{
    public class PrintLayoutCategoryTypes : Enumeration
    {
        public static PrintLayoutCategoryTypes RetailReceipt = new PrintLayoutCategoryTypes(1, nameof(RetailReceipt).ToLowerInvariant(), "RETAIL_RECEIPT");
        public static PrintLayoutCategoryTypes Kitchen = new PrintLayoutCategoryTypes(2, nameof(Kitchen).ToLowerInvariant(), "Kitchen");
        public static PrintLayoutCategoryTypes FoodAndBeverageReceipt = new PrintLayoutCategoryTypes(3, nameof(FoodAndBeverageReceipt).ToLowerInvariant(), "FB_Receipt");
  

        public PrintLayoutCategoryTypes(int id, string name, string value)
           : base(id, name)
        {
            Value = value;
        }

        public static IEnumerable<PrintLayoutCategoryTypes> List()
        {
            var list = new[] {

               RetailReceipt,
               Kitchen,
               FoodAndBeverageReceipt
           };

            return list;
        }
        public static PrintLayoutCategoryTypes FromName(string name)
        {
            var element = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (element == null)
            {
                throw new ArgumentException($"Possible values for PrintLayoutCategoryType : {string.Join(",", List().Select(s => s.Name))}");
            }

            return element;
        }

    }
}
