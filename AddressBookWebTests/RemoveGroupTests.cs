using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            _navigationHelper.OpenAuthPage();
            _loginHelper.Login(new AccountData("admin", "secret"));
            _navigationHelper.GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            _navigationHelper.ReturnToGroupsPage();
            LogOut();
        }
    }
}