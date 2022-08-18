using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent.Print.API
{
    public class MarkupLanguages : Enumeration
    {
        public PrintLayoutTypes PrintLayoutTypes { get; set; }
             
        public static MarkupLanguages HTML = new MarkupLanguages(1, nameof(HTML).ToLowerInvariant() , null);
        public static MarkupLanguages Star = new MarkupLanguages(2, nameof(Star).ToLowerInvariant() , PrintLayoutTypes.Markup);
        public static MarkupLanguages Epson = new MarkupLanguages(3, nameof(Epson).ToLowerInvariant(), PrintLayoutTypes.Markup);
        public static MarkupLanguages PDF = new MarkupLanguages(4, nameof(PDF).ToLowerInvariant(), PrintLayoutTypes.Stimul);
        public static MarkupLanguages BMP = new MarkupLanguages(5, nameof(BMP).ToLowerInvariant(), PrintLayoutTypes.Stimul);
 

        public MarkupLanguages(int id, string name, PrintLayoutTypes printLayoutTypes)
           : base(id, name)
        {
            PrintLayoutTypes = printLayoutTypes;
        }

        public static IEnumerable<MarkupLanguages> List()
        {
            var list = new[] {

              HTML,
              Star,
              Epson,
              PDF,
              BMP
           };

            return list;
        }
    
        public static MarkupLanguages FromName(string name)
        {
            var element = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (element == null)
            {
                throw new ArgumentException($"Possible values for MarkupLanguages : {string.Join(",", List().Select(s => s.Name))}");
            }

            return element;
        }

    }
}
