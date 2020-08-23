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
            _applicationManager.Contact.CreateIfNotExist(contactData);

            _applicationManager.Contact.Remove(1);
        }
    }
}