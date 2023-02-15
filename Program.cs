using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Xml.Serialization;
using static test_automation_2023.Step;



namespace test_automation_2023;

class Program
{
    static void Main(string[] args)
    {
        int i = 0;
        var origPath = @$"/orig/{i}screenshot.png";
        var newPath = @$"/new screenshots/{i}screenshot.png";
        var admin = "https://stage-admin.kidztopros.com/ktp-admin";
        var vendor = "https://stage-vendor.kidztopros.com/program-manager";
        var ktp = "https://stage.kidztopros.com";
        IWebDriver driver = new ChromeDriver();

        Step.OpenPage(driver, admin);
        


        driver.Manage().Cookies.DeleteAllCookies();
        driver.Navigate().GoToUrl(admin);
        driver.FindElement(By.Name("email")).SendKeys("");
        driver.FindElement(By.Name("password")).SendKeys("");
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        driver.FindElement(By.XPath("//a[contains(text(),'Schools')]")).Click();
        driver.FindElement(By.XPath(" //div[contains(text(),'Create New')]")).Click();
        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile($"/orig/{i}screenshot.png", ScreenshotImageFormat.Png);
        i++;


        Bitmap originImg = new Bitmap(origPath);
        int origHeight = originImg.Height;
        int origWidth = originImg.Width;
        List<Color> OrigColors = new List<Color>();


        Bitmap newImg = new Bitmap(newPath);
        int newHeight = newImg.Height;
        int newWidth = newImg.Width;
        List<Color> colors = new List<Color>();





    }

    static void ClickXpath(IWebDriver xyz, string xpath)
    {
        xyz.FindElement(By.XPath(xpath)).Click();
    }


    /// <summary>
    /// get all colors by pixel from image 
    /// </summary>
    /// <param name="img"></param>
    /// <param name="height"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    static List<Color> GetColors(Bitmap img, int height, int width)
    {
        List<Color> allPixelColors = new List<Color>();

        for (int i = height; height > 0; height--)
        {
            for (int j = width; width > 0; width--)
            {
                Color color = img.GetPixel(i, j);
                allPixelColors.Add(color);
            }
        }
        return allPixelColors;
    }


}


