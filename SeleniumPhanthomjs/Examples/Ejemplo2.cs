using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class Ejemplo2
    {


        public static int main()
        {

            int retorno = 1;

            var driverService = PhantomJSDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            driverService.HideCommandPromptWindow = true;

            IWebDriver _driver = new PhantomJSDriver(driverService);

            _driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement element = _driver.FindElement(By.Name("q"));
            string stringToSearchFor = "BDDfy";
            element.SendKeys(stringToSearchFor);
            element.Submit();

            //stringToSearchFor = "nda";




            string directorio = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\google.jpg");

            try
            {
                Screenshot SS = ((ITakesScreenshot)_driver).GetScreenshot();

                SS.SaveAsFile(directorio, ScreenshotImageFormat.Jpeg);

                //, ScreenshotImageFormat.Bmp);


                if (_driver.Title.Contains(stringToSearchFor))
                {
                    retorno = 0;
                }

                _driver.Quit();


            }
            catch (Exception ex)
            {
                directorio = string.Empty;

                directorio = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\error.txt");

                System.IO.StreamWriter file = new System.IO.StreamWriter(directorio);
                file.WriteLine(ex.Message);

                file.Close();
                Console.WriteLine(ex.Message);

                retorno = 1;

            }

            return retorno;

        }

    }
}
