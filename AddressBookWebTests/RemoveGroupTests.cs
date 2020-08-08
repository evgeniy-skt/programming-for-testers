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
            _groupHelper.SelectGroup(1);
            _groupHelper.DeleteGroup();
            _navigationHelper.ReturnToGroupsPage();
            LogOut();
        }
    }
}