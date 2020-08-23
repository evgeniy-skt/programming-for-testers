using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ModificationContactTests : AuthTestBase
    {
        [Test]
        public void ModificationContactTest()
        {
            var newContactData = new ContactData("Stepan", "Gogoidze");
            var contactData = new ContactData("Gogi", "Stepanidze");
            _applicationManager.Contact.CreateIfNotExist(contactData);
            var oldContacts = _applicationManager.Contact.GetContactList();
            ContactHelper.Modify(2, newContactData);
            var newContacts = _applicationManager.Contact.GetContactList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}