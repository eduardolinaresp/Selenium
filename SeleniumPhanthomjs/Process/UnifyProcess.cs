using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using SeleniumPhanthomjs.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs.Process
{
    public class UnifyProcess
    {

        private static BDContext dbase = new BDContext();

        public int Main()
        {

            int returnCode = 1;

            IWebDriver _driver = ConfigureDriver();

            List<urlPaginas> _lastPolyUrl = GetLastPolynomialPosted(_driver);

            List<urlPaginas> _urlsList = GetUrlsByLastPolynomialPosted(_driver, _lastPolyUrl[0]);

            List<StagingArea> _stageAreaListByMonth = new List<StagingArea>();

            foreach (var item in _urlsList)
            {
                _stageAreaListByMonth.AddRange(DoScrapingByMonth(_driver,item.url, item.Fecha));
            }

            _driver.Quit();

            if (SaveData(_stageAreaListByMonth))
            {
                returnCode = 0;
            }

            return returnCode;

        }

        private IEnumerable<StagingArea> DoScrapingByMonth(IWebDriver _driver, string _url, string _fecha)
        {

            var htmlDoc = new HtmlDocument();

            string htmlPage = HtmlInput(_driver, _url);

            htmlDoc.LoadHtml(htmlPage);

            var strHtmlDataList = 
                          (
                            from m in htmlDoc.DocumentNode
                                    .Descendants("div")
                                    .Where(d =>
                                           d.Attributes.Contains("class")
                                           &&
                                           d.Attributes["class"].Value.Contains("grid-canvas")
                                           )
                                    .SelectMany(tr => tr.Elements("div")
                                               .Where(p =>
                                                          p.Attributes.Contains("class")
                                                          &&
                                                          p.ChildNodes.Count() > 1
                                                      )
                                                ).ToList()
                                                 .Select(tr => tr.Elements("div")
                                                                 .Select(y => y.InnerText.Trim())
                                                        ).ToList()
                             select m.ToList()
                           ).ToList();


            //htmlDoc.OptionAutoCloseOnEnd = true;

            var TabStage = this.setStaginArea(strHtmlDataList, _fecha);

            var FinalTabStage = this.RemoveNotValidRows(TabStage);

            return FinalTabStage;
        }

        private List<StagingArea> RemoveNotValidRows(List<StagingArea> tabStage)
        {

            List<StagingArea> CleanStage = new List<StagingArea>();


            //var diccionario = new[] { "3", "4", "11", "12", "13"
            //                         ,"21", "22", "23", "24", "25"
            //                         ,"26", "27", "28", "29", "30"
            //                         ,"33", "34", "35"
            //                        };

            ////var dic = string.IsNullOrWhiteSpace;

          

            
            //tabStage.RemoveAll(p => diccionario.Contains(p._id));

            foreach (var mc in tabStage.Where(x => x.detalle.Contains("Valor UF")
                                                || x.detalle.Contains("Valor UTM")))
            {
                mc.valor = mc.unidad;
                mc.unidad = string.Empty;
            }

            tabStage.RemoveAll(p => p.valor.Contains(string.Empty));

            CleanStage = tabStage;


            return CleanStage;
        }

        private List<StagingArea> setStaginArea(List<List<string>> strHtmlDataList, string _fecha)
        {
            List<StagingArea> TabStage = new List<StagingArea>();

            for (int i = 0; i < strHtmlDataList.Count; i++)
            {
                StagingArea stg = new StagingArea();

                for (int j = 0; j < strHtmlDataList[i].Count; j++)
                {
                
                    switch (j)
                    {
                        case 0:

                            stg._id = strHtmlDataList[i][j].ToString();
                            break;
                        case 1:

                            stg.item = strHtmlDataList[i][j].ToString();
                            break;

                        case 2:

                            stg.detalle = strHtmlDataList[i][j].ToString();
                            break;

                        case 3:

                            stg.unidad = strHtmlDataList[i][j].ToString();
                            break;

                        case 4:

                            stg.valor = strHtmlDataList[i][j].ToString();
                            break;
                    }

                }

                stg.Fecha = _fecha;

                TabStage.Add(stg);

            }

            return TabStage;
            
        }

        private bool SaveData(List<StagingArea> FinalStaging)
        {
            bool IsCorrect = false;

            try
            {

                dbase.StageTable.AddRange(FinalStaging);

                dbase.SaveChanges();

                IsCorrect = true;

            }
            catch (Exception)
            {
                                 
                IsCorrect = false;
            }

            return IsCorrect;
        }

        private List<urlPaginas> GetUrlsByLastPolynomialPosted(IWebDriver _driver,
                                                               urlPaginas _urlPage)
        {

            string _baseUrl = _urlPage.url;

            _driver.Navigate().GoToUrl(_baseUrl);

            string _url = _driver.Url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_url);

            var hrefList = document.DocumentNode.SelectNodes("//a")
                           .Where(d =>
                                  d.Attributes.Contains("class")
                                  &&
                                  d.Attributes["class"].Value.Contains("heading")

                                  )
                           .Select(p => new
                                        {
                                         nommes = p.Attributes["title"].Value,
                                         url = p.GetAttributeValue("href", "not found").ToString()
                                        }
                                  ).ToList();

            int anio = 0;
            DateTime nomMes;

            List<urlPaginas> listupag = new List<urlPaginas>();

            foreach (var item in hrefList)
            {
                var splitter = item.nommes.Split(new char[0]).ToArray();

                urlPaginas upag = new urlPaginas();

                anio = 0;

                for (int i = 0; i < splitter.Count(); i++)
                {

                    if (int.TryParse(splitter[i], out anio))
                    {

                        upag.anio = anio;

                    }

                    if (DateTime.TryParse(string.Concat(splitter[i], "-", _urlPage.anio, "-", "01"), out nomMes))
                    {
                        upag.Fecha = nomMes.ToShortDateString();
                    }

                }


                upag.url = string.Concat("http://datos.gob.cl", item.url);
                listupag.Add(upag);

            }

            return listupag;
        }

        private List<urlPaginas> GetLastPolynomialPosted(IWebDriver _driver)
        {
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
                           .Select(p => new
                                       {
                                           stranio = p.InnerText.Where(Char.IsDigit),
                                           url = p.GetAttributeValue("href", "not found").ToString(),
                                           intanio = 0
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

                    numero = string.Concat(numero, item2);

                }

                int.TryParse(numero, out numeroint);
                upag.anio = numeroint;

                lstUpag.Add(upag);
            }


            int maxyear = lstUpag.Select(p => p.anio).Max();


            lstUpag.RemoveAll(p => p.anio != maxyear);


            return lstUpag;
        }

        private IWebDriver ConfigureDriver()
        {
            var driverService = PhantomJSDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            driverService.HideCommandPromptWindow = true;
            driverService.LoadImages = false;

            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);

            options.AddAdditionalCapability("applicationCacheEnabled", false);

            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla / 5.0(Windows NT 6.1) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 40.0.2214.94 Safari / 537.36");

            IWebDriver _driver = new PhantomJSDriver(driverService, options);
            _driver.Manage().Window.Size = new System.Drawing.Size(1280, 1024);
            return _driver;
        }


        private string HtmlInput(IWebDriver _driver, string _url)
        {

             _driver.Navigate().GoToUrl(_url);


            try
            {
                IWebElement objecElement = _driver.FindElement(By.XPath("html//body//iframe"));
                _driver.SwitchTo().Frame(objecElement);
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));


            wait.Until<IWebElement>((d) =>
            {

                try
                {
                    IWebElement element = d.FindElement(By.ClassName("data-view-container"));
                    if (element.Displayed &&
                        element.Enabled
                        //&&
                        //element.GetAttribute("class").Contains("grid-canvas")
                        )
                    {
                        return element;
                    }
                }
                catch (NoSuchElementException) { }
                catch (StaleElementReferenceException) { }

                return null;


            });


            string htmlPage = (string)_driver.PageSource.ToString();


            return htmlPage;


        }
    }
}
