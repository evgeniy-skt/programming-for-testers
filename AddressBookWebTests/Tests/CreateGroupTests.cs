using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            var oldGroupsList = _applicationManager.Group.GetGroupsList();

            _applicationManager.Group.Create(group);

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            Assert.AreEqual(oldGroupsList.Count + 1, newGroupsList.Count);
        }

        [Test]
        public void CreateGroupWithEmptyFieldsTest()
        {
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            var oldGroupsList = _applicationManager.Group.GetGroupsList();

            _applicationManager.Group.Create(group);

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            Assert.AreEqual(oldGroupsList.Count + 1, newGroupsList.Count);
        }
    }
}