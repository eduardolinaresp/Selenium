using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using SeleniumPhanthomjs.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class Internet
    {


        private static BDContext dbase = new BDContext();

        public int main()
        {

            var htmlDoc = new HtmlDocument();

            string htmlPage = HtmlInput();

            string htmlpage = htmlPage;

            htmlDoc.LoadHtml(htmlpage);

            var strListHtmlData = (from m in htmlDoc.DocumentNode
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
                                             .Select(y => y.InnerText.Trim()
                                                    )
                                     )
                                     .ToList()
                         select m.ToList()).ToList();


            //htmlDoc.OptionAutoCloseOnEnd = true;

            var TabStage = this.setStaginArea(strListHtmlData);

            var FinalTabStage = this.RemoveRowsNotvalid(TabStage);

            if (SaveData(FinalTabStage))
            {
                return 0;
            }
            else
            {
                return 1;
            }



        }

        private List<StagingArea> RemoveRowsNotvalid(List<StagingArea> tabStage)
        {

            List<StagingArea> CleanStage = new List<StagingArea>();

            var itemToRemove = tabStage.SingleOrDefault(r => r._id == "4");

           
                tabStage.Remove(itemToRemove);

            var diccionario = new[] { "3", "4", "11", "12", "13"
                                     ,"21", "22", "23", "24", "25"
                                     ,"26", "27", "28", "29", "30"
                                     ,"33", "34", "35"
                                    };

            tabStage.RemoveAll(p => diccionario.Contains(p._id));

            foreach (var mc in tabStage.Where(x => x.detalle.Contains("Valor UF") 
                                                || x.detalle.Contains("Valor UTM")))
            {
                mc.valor = mc.unidad;
                mc.unidad = string.Empty;
            }

                    

              CleanStage = tabStage;


            return CleanStage;
        }

        private List<StagingArea> setStaginArea(List<List<string>> html6)
        {
            List<StagingArea> TabStage = new List<StagingArea>();


            for (int i = 0; i < html6.Count; i++)
            {
                StagingArea stg = new StagingArea();

                for (int j = 0; j < html6[i].Count; j++)
                {


                    switch (j)
                    {
                        case 0:

                            stg._id = html6[i][j].ToString();
                            break;
                        case 1:

                            stg.item = html6[i][j].ToString();
                            break;

                        case 2:

                            stg.detalle = html6[i][j].ToString();
                            break;

                        case 3:

                            stg.unidad = html6[i][j].ToString();
                            break;

                        case 4:

                            stg.valor = html6[i][j].ToString();
                            break;
                    }

                }

                TabStage.Add(stg);

            }

            Console.WriteLine();


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
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                // Trace.TraceError("Error al grabar en BI_CGESTION");
                IsCorrect = false;
            }

            return IsCorrect;

        }




        private static string HtmlInput()
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


            _driver.Navigate().GoToUrl("http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017/resource/2e20f930-6e71-409f-8d17-b8d4202090b7");


            try
            {
                IWebElement objecElement = _driver.FindElement(By.XPath("html//body//iframe"));
                _driver.SwitchTo().Frame(objecElement);
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }



            //IWebElement objecElement = _driver.FindElement(By.XPath("//html//body//div//div//div//section//div//div//div//iframe"));



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



           
            string cadena = (string)_driver.PageSource.ToString();

            _driver.Quit();

            return cadena;


        }
    }
}
