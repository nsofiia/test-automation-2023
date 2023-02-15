using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using test_automation_2023;


namespace test_automation_2023
{
    public class DriverMethods
    {

        //open browser type
        public static void SelectBrowser(Preconditions.Browser provideValue)
        {
            IWebDriver driver;

            switch (provideValue)
            {
                case Preconditions.Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Preconditions.Browser.Safari:
                    driver = new SafariDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        //set browser dimensions for devise type
     //   public static void 







    }
}

