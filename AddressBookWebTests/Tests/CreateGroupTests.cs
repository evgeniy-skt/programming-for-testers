using System.Collections;
using System.Collections.Generic;
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

        [Test, TestCaseSource(nameof(RandomGroupDataProvider))]
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