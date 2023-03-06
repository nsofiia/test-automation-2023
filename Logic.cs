using System;
using System.Xml.Serialization;

namespace test_automation_2023
{
	public class Logic
	{
        const string PATH = @"TestCases.xml";
        static readonly XmlSerializer xml = new XmlSerializer(typeof(TestCase));

        /// <summary>
        /// save data to xml
        /// </summary>
        /// <param name="path">pathe where file created on the local machine</param>
        /// <param name="fileXml"></param>
        /// <param name="list"></param>
        public static void SaveToXml(TestCase testCase)
        {
            try
            {
                using (FileStream file = File.Create(PATH))
                //write list of testCases into the external file.xml
                {
                    xml.Serialize(file, testCase);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// retrieve data from xml
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <param name="fileXml"></param>
        /// <param name="list"></param>
        public static List<TestCase> RetrieveDataFromXml()
        {
            List<TestCase> list = new List<TestCase>();

            try
            {
                using (FileStream file = File.OpenRead(PATH))
                // retrieve the list from saved xml
                {
                    list = xml.Deserialize(file) as List<TestCase>;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }











    }
}

