using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : GroupTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            var groupData = new GroupData("Group name") {Header = "Group header", Footer = "Group footer"};
            var oldGroupsList = GroupData.GetAll();
            var toBeRemoved = oldGroupsList[0];
            _applicationManager.Group.CreateIfNotExist(groupData);

            _applicationManager.Group.Remove(toBeRemoved);

            Assert.AreEqual(oldGroupsList.Count - 1, _applicationManager.Group.GetGroupsListCount());

            var newGroupsList = GroupData.GetAll();
            oldGroupsList.RemoveAt(0);
            Assert.AreEqual(oldGroupsList, newGroupsList);

            foreach (var group in newGroupsList)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}