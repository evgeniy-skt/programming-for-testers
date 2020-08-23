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
            oldGroupsList.Add(group);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
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
            oldGroupsList.Add(group);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}