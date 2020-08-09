using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {
        [Test]
        public void CreateContactTest()
        {
            var contact = new ContactData("Gogi", "Stepanidze");
            _applicationManager.Contact.Create(contact);
        }
    }
}