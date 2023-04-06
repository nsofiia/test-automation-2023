using System;
using System.Xml.Serialization;

namespace test_automation_2023
{
    public static class Logic
    {
        public static XmlSerializer xml = new XmlSerializer(typeof(List<TestCase>));
        static string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "TestCases");
        /// <summary>
        /// save data to xml
        /// </summary>
        /// <param name="path">pathe where file created on the local machine</param>
        /// <param name="fileXml"></param>
        /// <param name="list"></param>
        public static void SaveToXml(List<TestCase> testCasesList)
        {
            try
            {
                Directory.CreateDirectory(xmlPath);
                FileStream file = File.Create(Path.Combine(xmlPath, "TestCases.xml"));
                xml.Serialize(file, testCasesList);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
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
                using (FileStream file = File.OpenRead(Path.Combine(xmlPath, "TestCases.xml")))
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

