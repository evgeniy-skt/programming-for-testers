using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            var oldGroupsList = _applicationManager.Group.GetGroupsList();
            _applicationManager.Group.CreateIfNotExist(group);

            _applicationManager.Group.Remove(0);

            Assert.AreEqual(oldGroupsList.Count - 1, _applicationManager.Group.GetGroupsListCount());

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            oldGroupsList.RemoveAt(0);
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}