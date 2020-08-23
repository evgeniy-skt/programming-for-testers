using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        [Test]
        public void CreateContactTest()
        {
            var contact = new ContactData("Gogi", "Stepanidze");
            var oldContacts = _applicationManager.Contact.GetContactList();

            _applicationManager.Contact.Create(contact);

            var newContacts = _applicationManager.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}