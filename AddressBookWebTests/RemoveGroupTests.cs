using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            OpenAuthPage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
            LogOut();
        }
    }
}