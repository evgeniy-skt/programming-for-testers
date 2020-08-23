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
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
    }
}