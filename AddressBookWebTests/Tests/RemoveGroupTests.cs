using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            _applicationManager.Navigator.GoToGroupsPage();
            _applicationManager.Group
                .SelectGroup(1)
                .DeleteGroup();
            _applicationManager.Navigator.ReturnToGroupsPage();
        }
    }
}