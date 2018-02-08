using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class directov4
    {


        public static int main()
        {

            var driverService = PhantomJSDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            driverService.HideCommandPromptWindow = true;
            driverService.LoadImages = false;

            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);

            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla / 5.0(Windows NT 6.1) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 40.0.2214.94 Safari / 537.36");

            IWebDriver _driver = new PhantomJSDriver(driverService, options);
            _driver.Manage().Window.Size = new System.Drawing.Size(1280, 1024);

            string _baseUrl = @"http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017/resource/2e20f930-6e71-409f-8d17-b8d4202090b7/view/8ed64e98-b346-46a8-9987-e998f8eef5e7";


            _driver.Navigate().GoToUrl(_baseUrl);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));

            //wait.Until<IWebElement>  ExpectedConditions.presenceOfElementLocated(container));

            //IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("someid")));

            //wait.Until<IWebElement>((d) =>
            //{
            //    IWebElement element = d.FindElement(By.ClassName("recline-data-explorer"));
            //    if (element.Displayed &&
            //        element.Enabled &&
            //        element.GetAttribute("class").Contains("grid-canvas"))
            //    {
            //        return element;
            //    }

            //    return null;
            //});

            //IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            //string title = (string)js.ExecuteScript("return document.getElementsByTagName('html')[0].className += ' js'");

            //Attributes["class"].Value.Contains("grid-canvas")

            string _finalUrl =  _driver.PageSource;

            var html = new HtmlDocument();

            string htmlpage = _finalUrl;


            html.LoadHtml(htmlpage);

            var parsedTb = html.DocumentNode
                           .Descendants("div")
                           .Where(d =>
                             d.Attributes.Contains("class")
                             &&
                             d.Attributes["class"].Value.Contains("grid-canvas")
                             )
                           .Select(tr => tr.Elements("div")
                                   .Where(ph =>
                                             ph.Attributes.Contains("class")
                                             // &&
                                             //ph.ChildNodes.Count() > 1

                                   )
                                .Select(td => td.InnerText.Trim())
                                .ToList()
                             )
                           //.Select(td => td.InnerText.Trim())
                           //.ToList()
                           .ToList();



            //var parsedTb = html.DocumentNode
            //   .Descendants("div")
            //   .Where(d =>
            //     d.Attributes.Contains("class")
            //     &&
            //     d.Attributes["class"].Value.Contains("grid-canvas")
            //     )
            //       .Select(tr => tr.Elements("div")
            //               .Where(ph =>
            //                         ph.Attributes.Contains("class")
            //                          &&
            //                         ph.ChildNodes.Count() > 1

            //               )
            //            //.Select(td => td.InnerText.Trim())
            //            //.ToList()
            //         )
            //   //.Select(td => td.InnerText.Trim())
            //   //.ToList()
            //   .ToList();


            //----------------------------------------------------

            _driver.Quit();



            return 1;

        }
    }
}
