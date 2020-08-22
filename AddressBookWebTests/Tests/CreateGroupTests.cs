using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            var group = new GroupData("Group name");
            group.Header = "Group header";
            group.Footer = "Group footer";
            _applicationManager.Group.Create(group);
        }

        [Test]
        public void CreateGroupWithEmptyFieldsTest()
        {
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            _applicationManager.Group.Create(group);
        }
    }
}