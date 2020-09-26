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

            _applicationManager.Contact.AddContactToGroup(contact, group);

            var newContact = group.GetContacts();
            oldContact.Add(contact);
            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
    }
}