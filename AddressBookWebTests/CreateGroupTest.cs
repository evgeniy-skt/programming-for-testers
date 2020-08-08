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
            _groupHelper.InitGroupCreation();
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            _groupHelper.FillGroupForm(group);
            _groupHelper.SubmitGroupCreation();
            _navigationHelper.ReturnToGroupsPage();
            LogOut();
        }
    }
}