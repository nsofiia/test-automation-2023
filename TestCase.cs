using System;
namespace test_automation_2023
{
	public class TestCase
	{
		public string UserName { get; set; } //username of a user who created the test case 
		public string  TestName { get; set; } //test name 
		public DateTime Date { get; set; } //date of last modification created/updated 
		public List<Step> Steps { get; set; } //list of steps inside of a test case 
	}
}

