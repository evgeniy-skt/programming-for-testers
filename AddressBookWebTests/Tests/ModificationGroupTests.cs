using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ModificationGroupTests : AuthTestBase
    {
        [Test]
        public void ModificationGroupTest()
        {
            var groupData = new GroupData("Group name") {Header = "Group header", Footer = "Group footer"};
            var oldGroupsList = _applicationManager.Group.GetGroupsList();
            var oldGroupElement = oldGroupsList[0];
            var newData = new GroupData("Edited name") {Header = "Edited header", Footer = "Edited footer"};
            _applicationManager.Group.CreateIfNotExist(groupData);

            _applicationManager.Group.Modify(0, newData);

            Assert.AreEqual(oldGroupsList.Count, _applicationManager.Group.GetGroupsListCount());

            var newGroupsList = _applicationManager.Group.GetGroupsList();
            oldGroupsList[0].Name = newData.Name;
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);

            foreach (var group in newGroupsList)
            {
                if (group.Id == oldGroupElement.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}