using System;
namespace test_automation_2023
{
    public class UI
    {
        public static void PrintIntro()
        {
            Console.WriteLine("New day - new adventure!");
        }


        public static void PrintOptions(int count)
        {
            switch (count)
            {
                case 0:
                    Console.WriteLine("Create new test case? press y");
                    break;
                default:
                    Console.WriteLine("Select test case to run from the list or create new, enter corresponding key");
                    break;
            }

        }

        public static void PrintSteps(List<string> listOfSteps)
        {
            Console.WriteLine("select step to add");
            foreach(string item in listOfSteps)
            {
                Console.WriteLine(item);
            }
            
        }





    }
}

