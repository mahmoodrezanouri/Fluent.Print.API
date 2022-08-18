using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluent.Print.API
{
    public class PrintLayoutTypes : Enumeration
    {
        public static PrintLayoutTypes Markup = new PrintLayoutTypes(1, nameof(Markup).ToLowerInvariant());
        public static PrintLayoutTypes PDF = new PrintLayoutTypes(2, nameof(PDF).ToLowerInvariant());
        public static PrintLayoutTypes CrystalReport = new PrintLayoutTypes(3, nameof(CrystalReport).ToLowerInvariant());
        public static PrintLayoutTypes Stimul = new PrintLayoutTypes(4, nameof(Stimul).ToLowerInvariant());

        public PrintLayoutTypes(int id, string name)
           : base(id, name)
        {
        }

        public static IEnumerable<PrintLayoutTypes> List()
        {
            var list = new[] {

              Markup,
              PDF,
              CrystalReport,
              Stimul
           };

            return list;
        }
        public static PrintLayoutTypes FromName(string name)
        {
            var element = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (element == null)
            {
                throw new ArgumentException($"Possible values for PrintLayoutTypes : {string.Join(",", List().Select(s => s.Name))}");
            }

            return element;
        }

    }
}
