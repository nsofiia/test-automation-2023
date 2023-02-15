using System;
namespace test_automation_2023
{
	public class TestCase
	{
		public BrowserType browser { get; set; }
		public Device device { get; set; }
		public string userName { get; set; } //username of a user who created the test case 
		public string  testName { get; set; } //test name 
		public DateTime date { get; set; } //date of last modification created/updated 
		public List<Step> steps { get; set; } //list of steps inside of a test case 
	}
}

