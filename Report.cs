using System;
namespace test_automation_2023
{
    public class Report
    {
        public string TestName; //from test case
        public DateTime DateTimeExecuted;
        //PassFail Outcome;
        public List<Step> FailedSteps = new List<Step>();
        //string ExceptionMessage;
        //string SaveAtLocation;
    }
}

