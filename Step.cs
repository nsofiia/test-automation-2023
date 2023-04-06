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
        public string Locator; //for xPath or by text search
        public string TextToType;
        public string OrigText; //storage location for text file to compare
        public string NewText;
        public string OrigImage;
        public string NewImg;
        [NonSerialized()] public IWebDriver Driver; //create enum with driver types or make it a step // TODO: Look up   [NonSerialized()]
        public StepType Type;     //enum with labels of kind of step
        public StepResult Result;

        public void SetDriver(IWebDriver dr)
        {
            Driver = dr;
        }

        public StepResult Execute()
        {
            Result = new StepResult();
            string new_textDirPath = Path.Combine(Directory.GetCurrentDirectory(), "user", "new_text");
            string orig_textDirPath = Path.Combine(Directory.GetCurrentDirectory(), "user", "orig_text");
            string report_textDirPath = Path.Combine(Directory.GetCurrentDirectory(), "user", "reports_text");
            string new_screenshDirPath = Path.Combine(Directory.GetCurrentDirectory(), "user", "new_screenshots");
            string orig_screenshDirPath = Path.Combine(Directory.GetCurrentDirectory(), "user", "orig_screenshots");

            switch (Type)
            {
                case StepType.GoToUrl:
                    Result.StepStarted = DateTime.Now;
                    //try
                    //{
                    Driver.Navigate().GoToUrl(Url);
                    Result.StepEnded = DateTime.Now;
                    //}
                    //catch (Exception e)
                    //{
                    //    Result.Exception = e.ToString();
                    //}
                    //if (Result.Exception != null)
                    //{
                    //    Result.Pass = false;
                    //}
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
                    Directory.CreateDirectory(new_screenshDirPath);
                    Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    string screenshotName = $"{DateTime.Now:yyyy.MM.dd-HH-mm-ss}.png";
                    string screenshotPath = Path.Combine(new_screenshDirPath, screenshotName);
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
                    // string textDirPath = Path.Combine(Directory.GetCurrentDirectory(), "new_text");
                    Directory.CreateDirectory(new_textDirPath);
                    NewText = $"{DateTime.Now:yyyy.MM.dd-HH-mm-ss}.txt";
                    string textPath = Path.Combine(new_textDirPath, NewText);
                    string text = Driver.FindElement(By.XPath(Locator)).Text;
                    File.WriteAllText(textPath, text);
                    break;

                case StepType.VerifyExistance:
                    Assert.IsTrue(Driver.FindElement(By.XPath(Locator)).Displayed);
                    break;

                case StepType.CloseBrowser:
                    Driver.Quit();
                    break;

                case StepType.CompareText:
                    Directory.CreateDirectory(report_textDirPath);
                    string[] origText = File.ReadAllLines(Path.Combine("user", orig_textDirPath, OrigText));
                    string[] newText = File.ReadAllLines(Path.Combine("user", new_textDirPath, NewText));
                    string reportTextName = $"{DateTime.Now:[HH.mm][dd.MM.yyyy]}.txt";

                    for (int i = 0; i < origText.Length; i++)
                    {
                        if (newText[i].Equals(origText[i]))
                        {
                            File.AppendAllText(Path.Combine("user", report_textDirPath, reportTextName),
                                "ORIGINAL " + Environment.NewLine+ Environment.NewLine + origText[i] + Environment.NewLine + Environment.NewLine + "Characters total: " + origText[i].Length + Environment.NewLine + Environment.NewLine + "FETCHED" + Environment.NewLine + Environment.NewLine + newText[i] + Environment.NewLine +  Environment.NewLine + "Characters total: " + origText[i].Count() + Environment.NewLine + Environment.NewLine +
                                "--- pass ---");
                        }
                        else
                        {
                            File.AppendAllText(Path.Combine("user", report_textDirPath, reportTextName),
                               "ORIGINAL " + Environment.NewLine + Environment.NewLine + origText[i] + Environment.NewLine + Environment.NewLine + "Characters total: " + origText[i].Count() + Environment.NewLine + Environment.NewLine + "FETCHED" + Environment.NewLine + Environment.NewLine + newText[i] + Environment.NewLine + Environment.NewLine + "Characters total: " + newText[i].Count() + Environment.NewLine + Environment.NewLine + "*** FAIL ***");
                        }

                    }

                    string[] reportCheck = File.ReadAllLines(Path.Combine("user", report_textDirPath, reportTextName));

                    for (int i = 0; i < reportCheck.Length; i++)
                    {         
                        if (reportCheck[i].Contains("FAIL"))
                        {
                            File.Move(Path.Combine("user", report_textDirPath, reportTextName), Path.Combine("user", report_textDirPath, "FAIL" + reportTextName));
                        }
                    }
                    break;




                    //bool textIsEqual = string.Equals(origText, newText);

                    //if (!textIsEqual)
                    //{

                    //}

                    //break;


                    //case StepType.CompareImages:

                    //    //to do

                    //    break;

            }
            return Result;
        }



        public void CompareImg()
        {

        }



    }
}

