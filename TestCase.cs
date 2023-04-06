using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;

namespace test_automation_2023
{
    public class TestCase
    {
        public string Name;
        public List<Step> Steps = new List<Step>();
        private IWebDriver _driver;

        public TestCase()
        {
        }
        public TestCase(string testName)
        {
            Name = testName;
        }

        public void  ChooseBrowser(BrowserType browser)
        {
          
            switch (browser)
            {
                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    break;
                case BrowserType.Safari:
                    _driver = new SafariDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }

        }



        public Report RunTest()
        {
            Report report = new Report();
            report.DateTimeExecuted = DateTime.Now;
          
            foreach (var step in Steps)
            {
                step.SetDriver(_driver);
                var result = step.Execute();
            }
            return report;
        }

    }
}

