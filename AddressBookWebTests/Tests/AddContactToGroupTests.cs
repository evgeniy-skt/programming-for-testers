using System.Linq;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroupTest()
        {
            var groupData = new GroupData("Group name") {Header = "Group header", Footer = "Group footer"};
            var contactData = new ContactData("Gogi", "Stepanidze");
            _applicationManager.Contact.CreateIfNotExist(contactData);
            _applicationManager.Group.CreateIfNotExist(groupData);

            var group = GroupData.GetAll()[0];
            var oldContact = group.GetContacts();
            _applicationManager.Contact.CreateAndAddContactToGroupIfNotExist();
            var contact = ContactData.GetAll().Except(oldContact).FirstOrDefault();

            _applicationManager.Contact.AddContactToGroup(contact, group);

            var newContact = group.GetContacts();
            oldContact.Add(contact);
            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
    }
}