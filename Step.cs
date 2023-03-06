using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using test_automation_2023;


namespace test_automation_2023
{
    public class Step
    {
        public int Width;
        public int Height;
        public string Url;
        public string Locator;
        public string TextToType;
        public string PathTextToCompare; //storage location for text file to compare
        public string PathImageToCompare;
        public IWebDriver Driver; //create enum with driver types or make it a step
        public StepType Type;     //enum with labels of kind of step


//        public Step(StepType st)
//        {
//            Type = st;
//}

    

        public StepResult Execute()
        {
            StepResult stepResult = new StepResult();

            switch (Type)
            {


                //ChooseBrowser,
                //SetWindowSize,!
                //GoToUrl,!
                //GetPageTitle,
                //FindElementByXpath,!
                //FindElementByPartialLinkText,!
                //ClickElementXpath,!
                //ClickElementByPartialLinkText,!
                //TakeScreenshot,!
                //Scroll,
                //AcceptAlert,
                //TypeText,!
                //ClearFieldByXpath,!
                //Back,!
                //Forward,!
                //Refresh,!
                //GetText,!
                //VerifyExistance,
                //CloseBrowser!


                case StepType.GoToUrl:
                    Driver.Navigate().GoToUrl(Url);
                    stepResult.Pass = true;
                    break;
                case StepType.SetWindowSize:
                    Driver.Manage().Window.Size = new System.Drawing.Size(Width, Height);
                    break;
                case StepType.FindElementByXpath:
                    Driver.FindElement(By.XPath(Locator));
                    break;
                case StepType.FindElementByPartialLinkText:
                    Driver.FindElement(By.PartialLinkText(Locator));
                    break;
                case StepType.ClickElementXpath:
                    Driver.FindElement(By.XPath(Locator)).Click();
                    break;
                case StepType.ClickElementByPartialLinkText:
                    Driver.FindElement(By.PartialLinkText(Locator)).Click();
                    break;
                case StepType.TypeText:
                    Driver.FindElement(By.XPath(Locator)).SendKeys(TextToType);//driver.FindElement(By.Name("q")).SendKeys("webdriver" + Keys.Enter);
                    break;
                case StepType.ClearFieldByXpath:
                    Driver.FindElement(By.XPath(Locator)).Clear();
                    break;


                case StepType.TakeScreenshot:
                    string screenshotsDirPath = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
                    Directory.CreateDirectory(screenshotsDirPath);
                    Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    string screenshotName = $"{DateTime.Now:yyyy.MM.dd-HH-mm-ss}.png";
                    string screenshotPath = Path.Combine(screenshotsDirPath, screenshotName);
                    screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                    break;



                case StepType.Refresh:
                    Driver.Navigate().Refresh();
                    break;
                case StepType.Forward:
                    Driver.Navigate().Forward();
                    break;
                case StepType.Back:
                    Driver.Navigate().Back();
                    break;

                case StepType.GetText:
                    string textDirPath = Path.Combine(Directory.GetCurrentDirectory(), "text");
                    Directory.CreateDirectory(textDirPath);
                    string textName = $"{DateTime.Now:yyyy.MM.dd-HH-mm-ss}.txt";
                    string textPath = Path.Combine(textDirPath, textName);
                    string text = Driver.FindElement(By.XPath(Locator)).Text;
                    File.WriteAllText(textPath, text);
                    break;

                case StepType.VerifyExistance:
                    Assert.IsTrue(Driver.FindElement(By.XPath(Locator)).Displayed);
                    break;

                case StepType.CloseBrowser:
                    Driver.Quit();
                    break;


                //case StepType.CompareImages:

                //    //to do

                //    break;

            }
            return stepResult;
        }



        public void CompareImg()
        {

        }



    }
}

