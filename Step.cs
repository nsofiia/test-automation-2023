using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace test_automation_2023
{
	public class Step
	{
        public int StepNumber { get; set; }
		public string StepName { get; set; }
		public DateTime UpdatedAt { get; set; }
        public string StepData { get; set; }


		public static void OpenPage(IWebDriver browserType, string location)
		{
            browserType.Navigate().GoToUrl(location);
		}



	}
}

