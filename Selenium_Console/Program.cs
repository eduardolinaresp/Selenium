using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Console
{
    class Program
    {

        IWebDriver driver = new ChromeDriver(); 

        static void Main(string[] args)
        {


        }

        //[SetUp]
        //public void Initialized()
        //{
           

        //    driver.Navigate().GoToUrl("https://www.google.cl");
        //}

        //[Test]
        //public void ExceutedTest()
        //{
        //    IWebElement element = driver.FindElement(By.Name("q"));

        //    element.SendKeys("executeautomation");
          
        //}

        //[TearDown]
        //public void CleanUp()
        //{
        //    driver.Close();
        //}


        [SetUp]
        public void Initialized()
        {


            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html");
            Console.WriteLine("open url");
        }

        [Test]
        public void ExceutedTest()
        {

            // title 

            SeleniumSetMethod.SelectDropDown(driver, "TitleId", "Mr.", "Id");

            // Initial 

            SeleniumSetMethod.EnterText(driver, "Initial", "Execute.", "Name");


            Console.WriteLine("valor desde title" + SeleniumGetMethod.GetTextFromDDL(driver, "TitleId", "Id"));

            Console.WriteLine("valor desde initial" + SeleniumGetMethod.GetText(driver, "Initial", "Name"));

            // click 

            SeleniumSetMethod.Click(driver, "Save", "Name");

            //IWebElement element = driver.FindElement(By.Name("q"));

            //element.SendKeys("executeautomation");

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }


    }


}
