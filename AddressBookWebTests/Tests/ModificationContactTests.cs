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
            
            var oldContacts = ContactData.GetAll();
            var oldGroupElement = oldContacts[0];

            ContactHelper.Modify(1, newContactData);

            Assert.AreEqual(oldContacts.Count, _applicationManager.Contact.GetGroupsListCount());

            var newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                if (contact.Id == oldGroupElement.Id)
                {
                    Assert.AreEqual(newContactData.FirstName,
                        contact.FirstName);
                    Assert.AreEqual(newContactData.LastName, contact.LastName);
                }
            }
        }
    }
}