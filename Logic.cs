using System;
using System.Xml.Serialization;

namespace test_automation_2023
{
    public class Logic
    {
        static readonly XmlSerializer xml = new XmlSerializer(typeof(List<TestCase>));

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
                string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "TestCases");
                Directory.CreateDirectory(xmlPath);
                FileStream file = File.Create(Path.Combine(xmlPath, "TestCases.xml")); 
                xml.Serialize(file, testCasesList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        ///// <summary>
        ///// retrieve data from xml
        ///// </summary>
        ///// <param name="path">path to the file</param>
        ///// <param name="fileXml"></param>
        ///// <param name="list"></param>
        //public static List<TestCase> RetrieveDataFromXml()
        //{
        //    List<TestCase> list = new List<TestCase>();

        //    try
        //    {
        //        using (FileStream file = File.OpenRead())
        //        // retrieve the list from saved xml
        //        {
        //            list = xml.Deserialize(file) as List<TestCase>;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return list;
        //}











    }
}

