using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using test_automation_2023;


namespace test_automation_2023;

class Program
{
    static void Main(string[] args)
    {
        DriverMethods.SelectBrowser(Preconditions.Browser.Safari);
       
    }

  

}


