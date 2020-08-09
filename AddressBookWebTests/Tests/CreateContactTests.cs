using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {
        [Test]
        public void CreateContactTest()
        {
            _applicationManager.Contact
                .InitContactCreation()
                .FillContactForm(new ContactData("Stepan", "Stepanov"))
                .SubmitContactCreation();
            _applicationManager.Navigator.ReturnToHomePage();
        }
    }
}