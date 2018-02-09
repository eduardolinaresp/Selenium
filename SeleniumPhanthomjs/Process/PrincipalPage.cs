using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class PrincipalPage
    {


        public int main()
        {

            //Selenium from class.

            int retorno = 1;

            var driverService = PhantomJSDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            driverService.HideCommandPromptWindow = true;
            driverService.LoadImages = false;

            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);

            options.AddAdditionalCapability("applicationCacheEnabled", false);

            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla / 5.0(Windows NT 6.1) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 40.0.2214.94 Safari / 537.36");

            IWebDriver _driver = new PhantomJSDriver(driverService, options);
            _driver.Manage().Window.Size = new System.Drawing.Size(1280, 1024);

            string _baseUrl = "http://datos.gob.cl/dataset";

            _driver.Navigate().GoToUrl(_baseUrl);

            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            try
            {
                IWebElement element = _driver.FindElement(By.Name("q"));
                string stringToSearchFor = "Polinómico";
                element.SendKeys(stringToSearchFor);
                element.Submit();
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }


            //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));


            //wait.Until<IWebElement>((d) =>
            //{

            //    try
            //    {
            //        IWebElement element = d.FindElement(By.("data-view-container"));
            //        if (element.Displayed &&
            //            element.Enabled
            //            //&&
            //            //element.GetAttribute("class").Contains("grid-canvas")
            //            )
            //        {
            //            return element;
            //        }
            //    }
            //    catch (NoSuchElementException) { }
            //    catch (StaleElementReferenceException) { }

            //    return null;


            //});


            string _url = _driver.Url;

            _driver.Quit();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_url);

            //GetListUrlToDocuments(document);


            var hrefList = document.DocumentNode.SelectNodes("//a")
                           .Where(d =>
                                 //d.Attributes.Contains("class")
                                 //&&
                                 d.Attributes.Contains("href")
                                 &&
                                 d.InnerText.Contains("Índices")
                                 )
                              //.Select(p => p.GetAttributeValue("href", "not found"))
                              .Select(p => new { stranio = p.InnerText.Where(Char.IsDigit)
                                                ,url =  p.GetAttributeValue("href", "not found").ToString() 
                                                , intanio = 0
                                                }
                              )
                             .ToList();

            string numero;
            int numeroint;

            List<urlPaginas> lstUpag = new List<urlPaginas>();

            foreach (var item in hrefList)
            {
                numero = string.Empty;

                urlPaginas upag = new urlPaginas();

                upag.url = string.Concat("http://datos.gob.cl", item.url);

                foreach (var item2 in item.stranio)
                {

                    numero = string.Concat(numero,item2);
      
                }
                
               int.TryParse(numero,out numeroint) ;
                upag.anio = numeroint;

                lstUpag.Add(upag);
            }


            int maxyear = lstUpag.Select(p => p.anio).Max();

                      
             lstUpag.RemoveAll(p => p.anio != maxyear);

             
            Char charRange = '/';

        


            //_driver.Url = "http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017/resource/2e20f930-6e71-409f-8d17-b8d4202090b7/view/8ed64e98-b346-46a8-9987-e998f8eef5e7";
            //_driver.Navigate();
            //the driver can now provide you with what you need (it will execute the script)
            //get the source of the page

            //fully navigate the dom

            //HtmlDocument document = new HtmlDocument();

            //_driver.SwitchTo().DefaultContent();

            //HtmlDocument iframeDoc = GetIframe(_driver);

            //iframeDoc.LoadHtml(_driver.PageSource);


            //var source = (string)_driver.PageSource;

            //string caena = _driver.PageSource.ToString();

            //document.LoadHtml(source.ToString());



            //document.LoadHtml(_driver.PageSource.ToString());

            //List<List<string>> findclasses = new List<List<string>>();

            //var findclasses = document.DocumentNode
            //    .Descendants("div")
            //    .Where(d =>
            //       d.Attributes.Contains("class")
            //       &&
            //       d.Attributes["class"].Value.Contains("grid-canvas")
            //     ).ToList();


            //List<IEnumerable<datos>> parsedTbl =

            //new List<Enumerable<datos>>();

            //parsedTbl = iframeDoc.DocumentNode
            //   .Descendants("div")
            //   .Where(d =>
            //     d.Attributes.Contains("class")
            //     &&
            //     d.Attributes["class"].Value.Contains("grid-canvas")
            //   ).Select(tr => tr.Elements("div")
            //            .Where(p =>
            //                p.Attributes.Contains("class")

            //            //&&
            //            //p.Attributes["class"].Value.Contains("l2")
            //            )
            //      .Select(td => td.InnerText.Trim())
            //      .ToList())
            //   .ToList();


            //var parsedTb = iframeDoc.DocumentNode
            //       .Descendants("div")
            //       .Where(d =>
            //         d.Attributes.Contains("class")
            //         &&
            //         d.Attributes["class"].Value.Contains("grid-canvas")
            //       ).Select(tr => tr.Elements("div")
            //                .Where(p =>
            //                       p.Attributes.Contains("class")
            //                      //&&
            //                     //p.Attributes["class"].Value.Contains("l2")
            //                )
            //                .Select(td => td.InnerText.Trim())
            //                .ToList())
            //       .ToList();





            //var hrefList = document.DocumentNode.SelectNodes("//a")
            //                   .Where(d =>
            //                         d.Attributes.Contains("class")
            //                         &&
            //                         d.Attributes["class"].Value.Contains("label"))
            //                      .Select(p => p.GetAttributeValue("href", "not found"))
            //                     .ToList();

            //var hrefList2 = document.DocumentNode.SelectNodes("//a")
            //                 .Where(d =>
            //                       d.Attributes.Contains("class")
            //                       &&
            //                       d.Attributes["class"].Value.Contains("label"))
            //                    .Select(p => p.GetAttributeValue("href", "not found"))
            //                   .ToList();


            //var pathElement = _driver.FindElement(By.Id("grid-canvas"));



            _driver.Quit();



            return retorno;

        }

        private static void GetListUrlToDocuments(HtmlDocument document)
        {
            var hrefList = document.DocumentNode.SelectNodes("//a")
                               .Where(d =>
                                     d.Attributes.Contains("class")
                                     &&
                                     d.Attributes["class"].Value.Contains("label"))
                                  .Select(p => p.GetAttributeValue("href", "not found"))
                                 .ToList();
        }

        private static HtmlDocument GetIframe(IWebDriver _driver)
        {
          
            _driver.Navigate().GoToUrl("http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017/resource/2e20f930-6e71-409f-8d17-b8d4202090b7");
            

            IWebElement objecElement = _driver.FindElement(By.XPath("//html//body//iframe"));

            _driver.SwitchTo().Frame(objecElement);

            //_driver.SwitchTo().Frame(0);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            HtmlAgilityPack.HtmlDocument iframeDoc = new HtmlAgilityPack.HtmlDocument();


            string cadena = (string)_driver.PageSource.ToString();

            return iframeDoc;
        }
    }
}
