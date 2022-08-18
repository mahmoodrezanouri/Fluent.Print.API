using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Models;

namespace Fluent.Print.API.Test
{
    [TestClass]
    public class FluentPrintDocumentBuilderTest
    {
        [TestMethod]
        public void Prepare_New_Print_Document()
        {
            var printData = PrepareTestData();

            var document = PrintDocumentBuilder
                  .Start()

                  .PrintLine(l => { l.Value = printData.Title; l.TemplateSection = "#Header"; })
                  .PrintLine(l =>
                  {
                      l.Value = printData.MiddleText;
                      l.SetStyle(s => { s.FontSize = FontSize.Large; s.Align = TextAlign.Middle; s.Bold = true; });
                      l.SetSpace(sp => sp.Size = 6.ToString());
                      l.TemplateSection = "#Middle";
                  })
                  .PrintGrid(g =>
                  {
                      g.TemplateSection = "#Grid";
                      g.WithHeader(h => h

                                    .Column(c => c.SetContent(cc => cc.Value = "Header 1"))
                                    .Column(c => c.SetContent(cc => cc.Value = "Header 2"))
                               );

                      g.ColumnSpace = 6;

                      g.Sections = printData.Sections.Select(sec =>

                          g.AddSection(s =>
                          {
                              s.Title = sec.Tilte;
                              s.Rows =
                              sec.Items.Select(i => s.AddRow(r => r.

                                  Bound(c => c.SetContent(cc => { cc.Value = i.Title; cc.SetStyle(s => s.Bold = true); }))
                                 .Bound(c => c.SetContent(cc => { cc.Value = i.Description; cc.SetStyle(s => s.Bold = true); })))).ToList();

                          })

                      ).ToList();

                  })
                  //g.Rows = printData.Items.Select(i =>
                  //g.AddRow(r => r.
                  //                Bound(c => c.SetContent(cc => { cc.Value = i.Title; cc.SetStyle(s => s.Bold = true); }))
                  //               .Bound(c => c.SetContent(cc => { cc.Value = i.Description; cc.SetStyle(s => s.Bold = true); }))

                  //)).ToList();


                  //.PrintMultipleElement(

                  //      e => e.PrintGrid(g =>
                  //      {
                  //          g.TemplateSection = "#Grid";
                  //          g.WithHeader(h => h

                  //                        .Column(c => c.SetContent(cc => { cc.Value = "Header 1"; cc.SetStyle(s => s.Bold = true); }))
                  //                        .Column(c => c.SetContent(cc => cc.Value = "Header 2"))
                  //                   );

                  //          g.ColumnSpace = 6;

                  //          g.Rows = printData.Items.Select(i =>
                  //          g.AddRow(r => r.
                  //                          Bound(c => c.SetContent(cc => { cc.Value = i.Title; cc.SetStyle(s => s.Bold = true); }))
                  //                         .Bound(c => c.SetContent(cc => { cc.Value = i.Description; cc.SetStyle(s => s.Bold = true); }))

                  //          )).ToList();
                  //      })

                  //)

                  .PrintLine(l => { l.Value = printData.FinalText; l.TemplateSection = "#Footer"; });


            var elements = document.Build();

            foreach(var el in elements)
            {
                Assert.IsNotNull(el);
            }

        }
        private PrintTestModel PrepareTestData()
        {
            var testData = new PrintTestModel()
            {
                Title = "Resturant Name",
                MainText = "Print Items :",
                MiddleText = "Reciept :",

                Sections = new List<SectionModel>()

                {

                new SectionModel()
                    {

                    Tilte = "Main",
                    Items = new List<PrintItemTestModel>() {

                     new PrintItemTestModel(){ Title = "Cake" , Description = "$20" },
                     new PrintItemTestModel(){ Title = "Coffee" , Description = "$5" },
                     new PrintItemTestModel(){ Title = "Salad" , Description = "$30" },
                     new PrintItemTestModel(){ Title = "Sugar" , Description = "$1" },
                     new PrintItemTestModel(){ Title = "Bloody Mary" , Description = "$2" }

                    }
                },
                 new SectionModel()
                    {

                    Tilte = "Dessert",
                    Items = new List<PrintItemTestModel>() {

                     new PrintItemTestModel(){ Title = "Cake2" , Description = "$20" },
                     new PrintItemTestModel(){ Title = "Coffee2" , Description = "$5" },
                     new PrintItemTestModel(){ Title = "Salad2" , Description = "$30" },
                     new PrintItemTestModel(){ Title = "Sugar2" , Description = "$1" },
                     new PrintItemTestModel(){ Title = "Bloody Mary2" , Description = "$2" }

                    }
                }

                },
                FinalText = "THANKS YOU FOR DINING WITH US!"

            };

            return testData;
        }
    }

}
