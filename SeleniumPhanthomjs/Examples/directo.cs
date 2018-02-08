using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs
{
    public class directo
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

            //string _finalUrl =  _driver.PageSource.ToString();



            var html = new HtmlDocument();

            //string row1 = @"<div class='ui-widget-content slick-row  odd' row='1' style='top:25px'><div class='slick-cell l0 r0'>2</div><div class='slick-cell l1 r1 active'>2</div><div class='slick-cell l2 r2'>Índice de remuneraciones(2)</div><div class='slick-cell l3 r3'>-</div><div class='slick-cell l4 r4'>3923.78</div></div>";
            //string row2 = @"<div class='ui-widget-content slick-row  odd' row='1' style='top:25px'><div class='slick-cell l0 r0'>2</div><div class='slick-cell l1 r1 active'>2</div><div class='slick-cell l2 r2'>Índice de remuneraciones (2)</div><div class='slick-cell l3 r3'>-</div><div class='slick-cell l4 r4'>3923.78</div></div>";
            //string row3 = @"<div class='ui-widget-content slick-row  even' row='2' style='top:50px'><div class='slick-cell l0 r0'>3</div><div class='slick-cell l1 r1'>Precios (3)</div><div class='slick-cell l2 r2'></div><div class='slick-cell l3 r3'></div><div class='slick-cell l4 r4'></div></div>";
            //string row4 = @"<div class='ui-widget-content slick-row  odd' row='3' style='top:75px'><div class='slick-cell l0 r0'>4</div><div class='slick-cell l1 r1'>ITEM</div><div class='slick-cell l2 r2'>D E T A L L E</div><div class='slick-cell l3 r3'>UNIDAD</div><div class='slick-cell l4 r4'>VALOR ($)</div></div>";
            //string row5 = @"<div class='ui-widget-content slick-row  even' row='4' style='top:100px'><div class='slick-cell l0 r0'>5</div><div class='slick-cell l1 r1'>3</div><div class='slick-cell l2 r2'>Petróleo Diesel (4)</div><div class='slick-cell l3 r3'>m3</div><div class='slick-cell l4 r4'>414275.097727</div></div>";
            //string row6 = @"<div class='ui-widget-content slick-row  odd' row='5' style='top:125px'><div class='slick-cell l0 r0'>6</div><div class='slick-cell l1 r1'>22</div><div class='slick-cell l2 r2 active'>Dólar observado</div><div class='slick-cell l3 r3'>$/US$</div><div class='slick-cell l4 r4'>642.41</div></div>";

            //string htmlpage = string.Concat(row1, row2, row3, row4, row5, row6);

            //html.LoadHtml(htmlpage);



            //html.Load(_finalUrl);

            html.Load(_driver.PageSource,Encoding.UTF8);


            var parsedTb = html
                          .DocumentNode
                          .Descendants("div")
                          .Where(d =>
                            d.Attributes.Contains("class")
                            &&
                            d.ChildNodes.Count() > 1
                          ).Select(tr => tr.Elements("div")
                                   .Where(p =>
                                          p.Attributes.Contains("class")
                                   )
                                   .Select(td => td.InnerText.Trim())
                                   .ToList())
                          .ToList();


            return 1;

        }
    }
}
