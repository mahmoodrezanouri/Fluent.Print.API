using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent.Print.API
{
    public class PrintersMarkupElements : BaseMarkupElement
    {
        public static BaseMarkupElement EpsonMarkupElements = new EpsonMarkupElements(0, nameof(EpsonMarkupElements).ToLowerInvariant(), "EPSON");
        public static BaseMarkupElement StarMarkupElements = new StarMarkupElements(1, nameof(StarMarkupElements).ToLowerInvariant(), "STAR");

        public PrintersMarkupElements(int id, string typeName, string tagName)
           : base(id , typeName , tagName)
        {
        }

        public static IEnumerable<BaseMarkupElement> List()
        {
            var list = new[] {

               EpsonMarkupElements,
               StarMarkupElements
           };

            return list;
        }
        public static BaseMarkupElement FromName(string name)
        {
            var element = List().SingleOrDefault(s => string.Equals(s.TagName, name, StringComparison.CurrentCultureIgnoreCase));

            if (element == null)
            {
                throw new ArgumentException($"Possible values for PrintersMarkupElements : {string.Join(",", List().Select(s => s.Name))}");
            }

            return element;
        }

    }
}
