using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
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

        public static IEnumerable<GroupData> GroupDataFromFile()
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

        [Test, TestCaseSource(nameof(GroupDataFromFile))]
        public void CreateGroupTest(GroupData group)
        {
            var oldGroupsList = _applicationManager.Group.GetGroupsList();

            _applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroupsList.Count + 1, _applicationManager.Group.GetGroupsListCount());

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            oldGroupsList.Add(group);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}