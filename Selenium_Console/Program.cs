using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Console
{
    class Program
    {

        IWebDriver driver = new ChromeDriver();

        private string _baseUrl { get; set; }


        static void Main(string[] args)
        {


        }

        //[SetUp]
        //public void Initialized()
        //{
           

        //    driver.Navigate().GoToUrl("https://www.google.cl");
        //}

        //[Test]
        //public void ExceutedTest()
        //{
        //    IWebElement element = driver.FindElement(By.Name("q"));

        //    element.SendKeys("executeautomation");
          
        //}

        //[TearDown]
        //public void CleanUp()
        //{
        //    driver.Close();
        //}


        [SetUp]
        public void Initialized()
        {

            _baseUrl = "http://www.bencinaenlinea.cl/web2/buscador.php?region=1";

            driver.Navigate().GoToUrl(_baseUrl);
            Console.WriteLine("open url");
        }

        [Test]
        public void ExceutedTest()
        {

            List<StagingArea> _stageAreaListByRegion = new List<StagingArea>();

            IList<IWebElement> regionslist = GetRegions(driver);

            foreach (var item in regionslist)
            {

                _stageAreaListByRegion.AddRange(DoScrapingByRegion(driver, item.Text, DateTime.Now));

            }

          
            Assert.IsTrue(_stageAreaListByRegion.Count >= 1);

        }

        private IEnumerable<StagingArea> DoScrapingByRegion(IWebDriver _driver, string _region, DateTime fecha)
        {

            List<StagingArea> TabStage = new List<StagingArea>();

            SeleniumSetMethod.SelectDropDown(_driver, "reporte_region", _region, "Name");

            SeleniumSetMethod.SelectDropDown(_driver, "reporte_combustible", "Petroleo Diesel", "Name");


            IList<IWebElement> elements = _driver.FindElements(By.CssSelector("input"));

            foreach (IWebElement element in elements)
            {
                if (element.GetAttribute("type").Equals("button"))
                {
                    element.Click();
                }
                
            }
           

            IWebElement table = _driver.FindElement(By.Id("tabla_resumen"));

            //Console.ReadKey();

            IList<IWebElement> rows = table.FindElements(By.TagName("td"));


            foreach (var item in rows)
            {

                StagingArea stg = new StagingArea();

                stg.Fecha = fecha.ToShortDateString();
                stg.Granularidad = "Diaro";
                stg.Tipo = "Petroleo";
                string[] nuemro = item.Text.Split(':');
                stg.Valor = nuemro[1];
                stg.Url = _baseUrl;

                TabStage.Add(stg);

            }


            return TabStage;
        }

        private IList<IWebElement> GetRegions(IWebDriver _driver)
        {
            List<IWebElement> allOptions = new List<IWebElement>();

            try
            {
                IWebElement selectElement = _driver.FindElement(By.Id("reporte_region"));
                SelectElement select = new SelectElement(selectElement);

                allOptions = select.Options.ToList();


            }
            catch (Exception) { }


            return allOptions;
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }


    }


}
