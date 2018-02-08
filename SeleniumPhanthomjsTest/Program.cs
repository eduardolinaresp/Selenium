using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumPhanthomjs
{
    class Program
    {
        private IWebDriver _driver;


        static void Main(string[] args)
        {

     


        }


        [SetUp]
        public void SetUp()
        {
            _driver = new PhantomJSDriver();
        }

        [Test]
        public void should_be_able_to_search_google()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement element = _driver.FindElement(By.Name("q"));
            string stringToSearchFor = "BDDfy";
            element.SendKeys(stringToSearchFor);
            element.Submit();

            stringToSearchFor = "nda";

            Assert.That(_driver.Title.Contains(stringToSearchFor));

            string directorio = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\google.jpg");

            try
            {
                Screenshot SS  = ((ITakesScreenshot)_driver).GetScreenshot();

                SS.SaveAsFile(directorio,  ScreenshotImageFormat.Jpeg);

                 //, ScreenshotImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                directorio = string.Empty;

                 directorio =  string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\error.txt");

                System.IO.StreamWriter file = new System.IO.StreamWriter(directorio);
                file.WriteLine(ex.Message);

                file.Close();
                Console.WriteLine(ex.Message);

            }

            
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }



    }
}
