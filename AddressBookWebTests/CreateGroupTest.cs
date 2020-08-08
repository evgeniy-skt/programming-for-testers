using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            OpenAuthPage();
            _loginHelper.Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();
        }
    }
}