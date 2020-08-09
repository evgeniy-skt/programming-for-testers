using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            _applicationManager.Navigator.GoToGroupsPage();
            _applicationManager.Group.Create(group);
            _applicationManager.Navigator.ReturnToGroupsPage();
        }

        [Test]
        public void CreateGroupWithEmptyFieldsTest()
        {
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            _applicationManager.Navigator.GoToGroupsPage();
            _applicationManager.Group.Create(group);
            _applicationManager.Navigator.ReturnToGroupsPage();
        }
    }
}