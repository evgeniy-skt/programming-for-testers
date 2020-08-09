using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            _applicationManager.Navigator.GoToGroupsPage();
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            _applicationManager.Group
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation();
            _applicationManager.Navigator.ReturnToGroupsPage();
        }
        
        [Test]
        public void CreateGroupWithEmptyFieldsTest()
        {
            _applicationManager.Navigator.GoToGroupsPage();
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            _applicationManager.Group
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation();
            _applicationManager.Navigator.ReturnToGroupsPage();
        }
    }
}