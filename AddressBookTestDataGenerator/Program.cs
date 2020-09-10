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
            var dataType = args[3];
            if (dataType == "groups")
            {
                var groups = new List<GroupData>();
                for (var i = 0; i < testDataCount; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "json")
                {
                    WriteGroupsToJSONFile(groups, writer);
                }
                else
                {
                    if (format == "xml")
                    {
                        WriteGroupsToXMLFile(groups, writer);
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized format" + format);
                    }
                }

                writer.Close();
            }
            else
            {
                if (dataType == "contacts")
                {
                    var contacts = new List<ContactData>();
                    for (var i = 0; i < testDataCount; i++)
                    {
                        contacts.Add(new ContactData(TestBase.GenerateRandomString(10),
                            TestBase.GenerateRandomString(20))
                        {
                            HomeAddress = TestBase.GenerateRandomString(20),
                            Email = TestBase.GenerateRandomString(15)
                        });
                    }

                    if (format == "json")
                    {
                        WriteGroupsToJSONFile(contacts, writer);
                    }
                    else
                    {
                        if (format == "xml")
                        {
                            WriteGroupsToXMLFile(contacts, writer);
                        }
                        else
                        {
                            Console.WriteLine("Unrecognized format" + format);
                        }
                    }

                    writer.Close();
                }
                else
                {
                    Console.WriteLine("Unknown data type" + dataType);
                }
            }
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

        static void WriteGroupsToXMLFile(List<ContactData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJSONFile(List<ContactData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
    }
}