using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {
        [Test]
        public void CreateContactTest()
        {
            _applicationManager.Navigator.OpenAuthPage();
            _applicationManager.Auth.Login(new AccountData("admin", "secret"));
            _applicationManager.Contact.InitContactCreation();
            _applicationManager.Contact.FillContactForm(new ContactData("Stepan", "Stepanov"));
            _applicationManager.Contact.SubmitContactCreation();
            _applicationManager.Navigator.ReturnToHomePage();
        }
    }
}