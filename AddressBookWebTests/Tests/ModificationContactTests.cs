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
            var oldContacts = _applicationManager.Contact.GetContactList();
            var oldGroupElement = oldContacts[0];

            _applicationManager.Contact.CreateIfNotExist(contactData);

            ContactHelper.Modify(2, newContactData);

            Assert.AreEqual(oldContacts.Count, _applicationManager.Contact.GetGroupsListCount());

            var newContacts = _applicationManager.Contact.GetContactList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                if (contact.Id == oldGroupElement.Id)
                {
                    Assert.AreEqual(newContactData.FirstName + newContactData.LastName,
                        contact.FirstName);
                }
            }
        }
    }
}