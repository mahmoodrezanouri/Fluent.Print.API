using CSScriptLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Models;

namespace Fluent.Print.API.Test
{
    public class PrintMarkupDocumentTest
    {
        [TestMethod]
        public void Test_Print_Markup()
        {
            var printData = PrepareTestData();

            var strPrintLayout = File.ReadAllText("~//Markups//FAndBPrintCheck.txt", Encoding.UTF8);
            
            CSScript.Evaluator.ReferenceAssembliesFromCode(strPrintLayout);
            dynamic block = CSScript.Evaluator.LoadCode(strPrintLayout);
            var printDocumentBuilder = block.SendPrint(printData);

            var result = (IEnumerable<IFluentPrintDocumentBuilder>)printDocumentBuilder;

            foreach(var document in result)
            {
                Assert.IsNotNull(document);
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
