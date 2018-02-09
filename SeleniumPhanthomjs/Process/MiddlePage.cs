using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs.Process
{
    public class MiddlePage
    {

        public int Main()
        {

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

            string _baseUrl = "http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017";

            _driver.Navigate().GoToUrl(_baseUrl);


            string _url = _driver.Url;


            _driver.Quit();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_url);

          
            var hrefList = document.DocumentNode.SelectNodes("//a")
                        .Where(d =>
                                  d.Attributes.Contains("class")
                                  &&
                                  d.Attributes["class"].Value.Contains("heading")

                              )
                         .Select(p => new {
                                            nommes = p.Attributes["title"].Value
                                           , url = p.GetAttributeValue("href", "not found").ToString()
                                           }
                                 )
                         .ToList();

            int anio = 0;
            DateTime nomMes;

            List<urlPaginas> listupag = new List<urlPaginas>();

            foreach (var item in hrefList)
            {
              var splitter =  item.nommes.Split(new char[0]).ToArray();

                urlPaginas upag = new urlPaginas();

                anio = 0;

                for (int i = 0; i < splitter.Count(); i++)
                {

                   if (int.TryParse(splitter[i],out anio))
                    {

                        upag.anio = anio;

                    }

                    if (DateTime.TryParse(string.Concat(splitter[i],"-" , "2017", "-","01"), out nomMes))
                    {
                        upag.Fecha = nomMes.ToShortDateString();
                    }
             
                }


                upag.url = item.url;
                listupag.Add(upag);
                                                               
            }

                     


            return 1; 

        }

    }
}
