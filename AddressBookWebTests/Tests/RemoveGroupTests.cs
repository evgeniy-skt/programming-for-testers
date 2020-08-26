using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            var groupData = new GroupData("Group name") {Header = "Group header", Footer = "Group footer"};
            var oldGroupsList = _applicationManager.Group.GetGroupsList();
            _applicationManager.Group.CreateIfNotExist(groupData);

            _applicationManager.Group.Remove(0);

            Assert.AreEqual(oldGroupsList.Count - 1, _applicationManager.Group.GetGroupsListCount());

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            var toBeRemoved = oldGroupsList[0];
            oldGroupsList.RemoveAt(0);
            Assert.AreEqual(oldGroupsList, newGroupsList);

            foreach (var group in newGroupsList)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}