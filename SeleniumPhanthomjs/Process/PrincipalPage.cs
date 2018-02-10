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

            int retorno = 1;

            var driverService = PhantomJSDriverService.
            CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
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

           try
            {
                IWebElement element = _driver.FindElement(By.Name("q"));
                string stringToSearchFor = "Polinómico";
                element.SendKeys(stringToSearchFor);
                element.Submit();
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }


           string _url = _driver.Url;

            _driver.Quit();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_url);

    

            var hrefList = document.DocumentNode.SelectNodes("//a")
                           .Where(d =>
                                 //d.Attributes.Contains("class")
                                 //&&
                                 d.Attributes.Contains("href")
                                 &&
                                 d.InnerText.Contains("Índices")
                                 )
                            .Select(p => new { stranio = p.InnerText.Where(Char.IsDigit)
                                                ,url =  p.GetAttributeValue("href", "not found").ToString() 
                                                ,intanio = 0
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

      
    }
}
