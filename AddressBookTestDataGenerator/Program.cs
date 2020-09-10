using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AddressBookWebTests;
using Newtonsoft.Json;

namespace AddressBookTestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var testDataCount = Convert.ToInt32(args[0]);
            var writer = new StreamWriter(args[1]);
            var format = args[2];
            var groups = new List<GroupData>();
            for (var i = 0; i < testDataCount; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            if (format == "csv")
            {
                WriteGroupsToCSVFile(groups, writer);
            }
            else
            {
                if (format == "xml")
                {
                    WriteGroupsToXMLFile(groups, writer);
                }
                else
                {
                    if (format == "json")
                    {
                        WriteGroupsToJSONFile(groups, writer);
                    }

                    else
                    {
                        Console.WriteLine("Unrecognized format" + format);
                    }
                }
            }

            writer.Close();
        }

        static void WriteGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteLine(
                    $"{group.Name},{group.Header},{group.Footer}");
            }
        }

        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
    }
}