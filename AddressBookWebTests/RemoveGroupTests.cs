using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            _applicationManager.Navigator.OpenAuthPage();
            _applicationManager.Auth.Login(new AccountData("admin", "secret"));
            _applicationManager.Navigator.GoToGroupsPage();
            _applicationManager.Group.SelectGroup(1);
            _applicationManager.Group.DeleteGroup();
            _applicationManager.Navigator.ReturnToGroupsPage();
        }
    }
}