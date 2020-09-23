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
            var oldContacts = ContactData.GetAll();
            _applicationManager.Contact.CreateIfNotExist(contactData);

            _applicationManager.Contact.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, _applicationManager.Contact.GetGroupsListCount());

            var newContacts = ContactData.GetAll();
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