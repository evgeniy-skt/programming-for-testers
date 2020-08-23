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
            ContactHelper.Modify(0, newContactData);
        }
    }
}