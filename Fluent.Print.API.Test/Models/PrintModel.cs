using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    public class PrintTestModel
    {
        public string Title { get; set; }
        public string MainText { get; set; }

        public string MiddleText { get; set; }

        public string FinalText { get; set; }

        public IEnumerable<SectionModel> Sections { get; set; }


    }
    public class SectionModel
    {

        public string Tilte { get; set; }
        public IEnumerable<PrintItemTestModel> Items { get; set; }

    }
    public class PrintItemTestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
