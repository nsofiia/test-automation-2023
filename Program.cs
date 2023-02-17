using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using test_automation_2023;
using static test_automation_2023.ImageToCompare;


namespace test_automation_2023;

class Program
{
    static void Main(string[] args)
    {

        //create test case with steps
        //create preconditions for environments in which test case is run
        //run test case
        //generate report

        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.google.com/");
        driver.Manage().Window.Size = new System.Drawing.Size(500, 500);

        // Take a screenshot of the current browser window
        ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
        Screenshot screenshot = screenshotDriver.GetScreenshot();

        // Save the screenshot to a file
        screenshot.SaveAsFile(@"\screenshots\example.png");

        // Quit the driver
        driver.Quit();







    }



}


