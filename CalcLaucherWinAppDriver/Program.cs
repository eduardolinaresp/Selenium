using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Service;

namespace CalcLaucherWinAppDriver
{
    class Program
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        protected static WindowsDriver<WindowsElement> session;
        private static WindowsElement header;
        private static WindowsElement calculatorResult;

        static void Main(string[] args)
        {



            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", CalculatorAppId);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);


            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

            session.FindElementById("1").Click();
            //session.FindElementByName("mas").Click();
            //session.FindElementByName("siete").Click();
            //session.FindElementByName("igual").Click();


            session.Quit();
            session = null;


        }

    }
}
