using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveContactTests : AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            var contactData = new ContactData("Gogi", "Stepanidze");
            var oldContacts = _applicationManager.Contact.GetContactList();
            _applicationManager.Contact.CreateIfNotExist(contactData);

            _applicationManager.Contact.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, _applicationManager.Contact.GetGroupsListCount());

            var newContacts = _applicationManager.Contact.GetContactList();
            var toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}