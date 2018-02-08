using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.UI;

namespace Selenium_Console
{
    public class SeleniumGetMethod
    {

        public static string GetText(IWebDriver driver, string element,  string elementtype)
        {

            if (elementtype == "Id")
            {
                return driver.FindElement(By.Id(element)).GetAttribute("value");
            }
            if (elementtype == "Name")
            {
                return driver.FindElement(By.Name(element)).GetAttribute("value");
            }
            else
            {
                return String.Empty;
            }

        }


        public static string GetTextFromDDL(IWebDriver driver, string element, string elementtype)
        {

            if (elementtype == "Id")
            {
                return new SelectElement(driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            }
            if (elementtype == "Name")
            {
                return new SelectElement(driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            }
            else
            {
                return String.Empty;
            }

        }

        public static void Click(IWebDriver driver, string element, string elementtype)
        {

            if (elementtype == "id")
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementtype == "name")
            {
                driver.FindElement(By.Name(element)).Click();
            }
        }


        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "id")
            {
               new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            }
            if (elementtype == "name")
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
            }
        }


        public static void SelectDropDownList(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "id")
            {
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            }
            if (elementtype == "name")
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
            }
        }

    }
}
