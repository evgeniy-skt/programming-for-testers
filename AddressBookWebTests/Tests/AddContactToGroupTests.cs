using System.Linq;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroupTest()
        {
            var group = GroupData.GetAll()[0];
            var oldContact = group.GetContacts();
            var contact = ContactData.GetAll().Except(oldContact).FirstOrDefault();
            var newContact = group.GetContacts();
            oldContact.Add(contact);
            newContact.Sort();
            oldContact.Sort();

            _applicationManager.Contact.AddContactToGroup(contact, group);

            Assert.AreEqual(oldContact, newContact);
        }
    }
}