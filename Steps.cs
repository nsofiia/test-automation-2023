using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using test_automation_2023;


namespace test_automation_2023
{
    public class Steps
    {








        //open browser type
        public IWebDriver SelectBrowser(string value)
        {
            IWebDriver driver;

            switch (value)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Safari":   //test
                    driver = new SafariDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            return driver;

        }

        //set browser dimensions for devise type

        public void SetDimensions(IWebDriver driver, int width, int height)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);

        }



        
    }
}

