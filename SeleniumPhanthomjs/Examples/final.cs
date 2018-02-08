using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class final
    {
        

        public static int main()
        {
            int retorno = 1;

             HtmlAgilityPack.HtmlDocument iframeDoc = new HtmlAgilityPack.HtmlDocument();

            var driverService = PhantomJSDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            driverService.HideCommandPromptWindow = true;
            driverService.LoadImages = false;

            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);

            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla / 5.0(Windows NT 6.1) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 40.0.2214.94 Safari / 537.36");

            IWebDriver _driver = new PhantomJSDriver(driverService, options);
            _driver.Manage().Window.Size = new System.Drawing.Size(1280, 1024);

            string _baseUrl = "http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017/resource/2e20f930-6e71-409f-8d17-b8d4202090b7";


            _driver.Navigate().GoToUrl(_baseUrl);

            IWebElement objecElement = _driver.FindElement(By.XPath("//html//body//iframe"));

            _driver.SwitchTo().Frame(objecElement);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            string cadena = (string)_driver.PageSource;

            string cadena2 = _driver.PageSource.ToString();


            //iframeDoc.LoadHtml(_driver.PageSource);
            iframeDoc.LoadHtml(cadena.Trim());
            //iframeDoc.LoadHtml(cadena2);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            var html1 = iframeDoc.DocumentNode
                   .Descendants("div")
                   .Where(d =>
                     d.Attributes.Contains("class")
                     &&
                     d.Attributes["class"].Value.Contains("grid-canvas")
                     ).Select(p => p.Descendants(
                     "div")
               .Where(d =>
                 d.Attributes.Contains("class")
                 &&
                 d.ChildNodes.Count() > 1
               ).Select(tr => tr.Elements("div")
                        .Where(ph =>
                               ph.Attributes.Contains("class")
                        )
                        .Select(td => td.InnerText.Trim())
                        .ToList())
               .ToList());

            string numero = "1";

            iframeDoc.OptionAutoCloseOnEnd = true;

               _driver.Quit();

            return retorno;

        }
    }
}
