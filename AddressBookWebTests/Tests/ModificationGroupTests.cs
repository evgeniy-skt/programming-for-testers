using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ModificationGroupTests : AuthTestBase
    {
        [Test]
        public void ModificationGroupTest()
        {
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            var newData = new GroupData("Edited name") {Header = "Edited header", Footer = "Edited footer"};
            _applicationManager.Group.CreateIfNotExist(group);
            _applicationManager.Group.Modify(1, newData);
        }
    }
}