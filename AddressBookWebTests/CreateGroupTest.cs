using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            _navigationHelper.OpenAuthPage();
            _loginHelper.Login(new AccountData("admin", "secret"));
            _navigationHelper.GoToGroupsPage();
            InitGroupCreation();
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            _navigationHelper.ReturnToGroupsPage();
            LogOut();
        }
    }
}