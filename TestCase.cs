using System;
namespace test_automation_2023
{
	public class TestCase
	{
		public int number = 0;
		public string name = " ";
		public List<Steps> steps;
		public Report report = new Report();



		public TestCase(string nameOf)
		{
			number += 1;
		}


	}

	
}

