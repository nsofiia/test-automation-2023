using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using test_automation_2023;
using static test_automation_2023.ImageToCompare;
using static test_automation_2023.Step;
using static test_automation_2023.UI;
using static test_automation_2023.Logic;


namespace test_automation_2023;

class Program
{



    static void Main(string[] args)
    {
      
        List<string> stepNames = new List<string> { "ChooseBrowser",
        "SetWindowSize",
        "GoToUrl",
        "GetPageTitle",
        "FindElementByXpath",
        "FindElementByPartialLinkText",
        "ClickElementXpath",
        "ClickElementByPartialLinkText",
        "TakeScreenshot",
        "Scroll",
        "AcceptAlert",
        "TypeText",
        "ClearFieldByXpath",
        "Back",
        "Forward",
        "Refresh",
        "GetText",
        "VerifyExistance",
        "CloseBrowser"};
        //create test case with steps, save
        //create preconditions for environments in which test case is run: browser type, window dimwnsions
        //save different types of environments
        //run test case in selected environment
        //generate report for environment + test case + datetime
        PrintIntro();

        List<TestCase> testCases = new List<TestCase>(); //RetrieveDataFromXml();
                                                         //int testCaseCount = testCases.Count;
                                                         //PrintOptions(testCaseCount);
                                                         //char answer = Console.ReadKey().KeyChar;
                                                         //if (answer == 'y')
                                                         //{
        TestCase newTest = new TestCase("test");
        Step s = new Step();
        s.Type = StepType.GoToUrl;
        // s.Url = "https://stage-admin.kidztopros.com/";
        s.Url = "https://stage.kidztopros.com/";
        newTest.Steps.Add(s);

        Step s2 = new Step();
        s2.Type = StepType.SetWindowSize;
        s2.Width = 320;
        s2.Height = 700;
        newTest.Steps.Add(s2);

        Step s1 = new Step();
        s1.Type = StepType.GetText;
        s1.Locator = "//body/div[@id='__next']/div[1]/div[1]/section[1]/div[2]/div[1]/div[2]/div[2]";
        //s1.TextToType = "admin+stage@kidztopros.com";
        newTest.Steps.Add(s1);

        //Step s5 = new Step();
        //s5.Type = StepType.ClearFieldByXpath;
        //s5.Locator = "//input[@name = \"email\"]";
        //newTest.Steps.Add(s5);

        Step s3 = new Step();
        s3.Type = StepType.TakeScreenshot;
        newTest.Steps.Add(s3);

        Step s4 = new Step();
        s4.Type = StepType.CloseBrowser;
        newTest.Steps.Add(s4);

        testCases.Add(newTest);

        SaveToXml(testCases);
       // Console.ReadKey();
        RetrieveDataFromXml();



        newTest.ChooseBrowser(BrowserType.Safari);
        newTest.RunTest();

        //  newTest.ChooseBrowser(BrowserType.Safari);

        //  newTest.RunTest();

        //   newTest.RunTest();

        //   PrintSteps(stepNames);







        //  Step step = new Step("google.com");

        //  step.Execute(StepType.GoToUrl);
        System.Environment.Exit(1);
    }






}






