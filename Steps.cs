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

        //set browser dimensions for devise type

        public void SetDimensions(IWebDriver driver, int width, int height)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);

        }


        public void GoToPage(IWebDriver wDriver,  string url)
        {
            wDriver.Navigate().GoToUrl(url);
        }

        
        public string SaveScreenshot(IWebDriver wDriver)
        {
            string imgName = "screenshot" + DateTime.Now;
            // Take a screenshot of the current browser window
            ITakesScreenshot screenshotDriver = wDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            // Save the screenshot to a file
            screenshot.SaveAsFile(imgName);
            return imgName;
        }

      
        public void CloseBrowser(IWebDriver wDriver)
        {
            // Quit the driver
            wDriver.Quit();

        }



    }
}

