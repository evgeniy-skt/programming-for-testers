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
            var oldGroupsList = _applicationManager.Group.GetGroupsList();
            var newData = new GroupData("Edited name") {Header = "Edited header", Footer = "Edited footer"};
            _applicationManager.Group.CreateIfNotExist(group);

            _applicationManager.Group.Modify(0, newData);

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            oldGroupsList[0].Name = newData.Name;
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}