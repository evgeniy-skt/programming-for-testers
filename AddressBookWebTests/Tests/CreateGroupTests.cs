using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            var groups = new List<GroupData>();
            for (var i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCSVFile()
        {
            var groups = new List<GroupData>();
            var lines = File.ReadAllLines(@"groups.csv");
            foreach (var line in lines)
            {
                var partLine = line.Split(',');
                groups.Add(new GroupData(partLine[0])
                {
                    Header = partLine[1],
                    Footer = partLine[2],
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource(nameof(GroupDataFromJSONFile))]
        public void CreateGroupTest(GroupData group)
        {
            var oldGroupsList = GroupData.GetAll();

            _applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroupsList.Count + 1, _applicationManager.Group.GetGroupsListCount());

            var newGroupsList = GroupData.GetAll();
            oldGroupsList.Add(group);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }

        [Test]
        public void TestDBConnection()
        {
            foreach (var contact in GroupData.GetAll()[0].GetContacts())
            {
                Console.WriteLine(contact);
            }
        }
    }
}