using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            _applicationManager.Group.CreateIfNotExist(group);
            _applicationManager.Group.Remove(1);
        }
    }
}