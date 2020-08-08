using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            _applicationManager.Navigator.OpenAuthPage();
            _applicationManager.Auth.Login(new AccountData("admin", "secret"));
            _applicationManager.Navigator.GoToGroupsPage();
            _applicationManager.Group.InitGroupCreation();
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            _applicationManager.Group.FillGroupForm(group);
            _applicationManager.Group.SubmitGroupCreation();
            _applicationManager.Navigator.ReturnToGroupsPage();
        }
    }
}