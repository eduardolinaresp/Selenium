using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class datosGov
    {


        public static int main()
        {

            //Selenium from class.

            int retorno = 1;

            var driverService = PhantomJSDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
            driverService.HideCommandPromptWindow = true;
            driverService.LoadImages = false;

            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("IsJavaScriptEnabled", true);

            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla / 5.0(Windows NT 6.1) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 40.0.2214.94 Safari / 537.36");

            IWebDriver _driver = new PhantomJSDriver(driverService, options);
            _driver.Manage().Window.Size = new System.Drawing.Size(1280, 1024);

            string _baseUrl = "http://datos.gob.cl/dataset";

            _driver.Navigate().GoToUrl(_baseUrl);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            IWebElement element = _driver.FindElement(By.Name("q"));

            string stringToSearchFor = "Polinómico";
            element.SendKeys(stringToSearchFor);
            element.Submit();

            string _url = _driver.Url;


            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_url);



            //var hrefList = document.DocumentNode.SelectNodes("//a")
            //                   .Where(d =>
            //                         d.Attributes.Contains("class")
            //                         &&
            //                         d.Attributes["class"].Value.Contains("label"))
            //                      .Select(p => p.GetAttributeValue("href", "not found"))
            //                     .ToList();



            //Char charRange = '/';

            //for (int i = 0; i < hrefList.Count; i++)
            //{


            //    //string startIndex = hrefList[i].IndexOf(charRange);

            //    string s = hrefList[i].ToString();


            //    int startIndex = s.Length;

            //    int endIndex = s.LastIndexOf(s);

            //    int length = endIndex - startIndex + 1;


            //    s.Substring(startIndex, length);

            //    string to_url = string.Concat(_baseUrl, s);


            //}

            //foreach (var item in hrefList)
            //{
            //    _url = _url.Concat(item.);


            //}




            //int x = 1;


            
            ////IWebElement element2 =  _driver.FindElement(By.ClassName("loading-dialog"));


            ////for (int i = 0; i < elements.; i++)
            ////{
            ////    Console.WriteLine(elements.get(i).getAttribute("href"));
            ////}


            //x = 2;







            //_driver.Url = "http://datos.gob.cl/dataset/indices-y-precios-para-el-calculo-del-reajuste-polinomico-ano-2017/resource/2e20f930-6e71-409f-8d17-b8d4202090b7/view/8ed64e98-b346-46a8-9987-e998f8eef5e7";
            //_driver.Navigate();
            //the driver can now provide you with what you need (it will execute the script)
            //get the source of the page

            //fully navigate the dom

            //HtmlDocument document = new HtmlDocument();

            //_driver.SwitchTo().DefaultContent();

            HtmlDocument iframeDoc = GetIframe(_driver);

            iframeDoc.LoadHtml(_driver.PageSource);


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
               .ToList()


                     );



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



            string directorio = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\Polinómico.jpg");

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
