using System;
using System.Linq;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class RemoveContactFromGroup : AuthTestBase

    {
        [Test]
        public void RemoveContactFromGroupTest()
        {
            var group = GroupData.GetAll()[0];
            var oldContact = group.GetContacts();
            var contact = ContactData.GetAll().FirstOrDefault();

            _applicationManager.Contact.RemoveContactFromGroup(contact, group);

            oldContact.RemoveAt(oldContact.IndexOf(contact));
            var newContact = group.GetContacts();
            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
    }
}