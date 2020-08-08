using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {
        [Test]
        public void CreateContactTest()
        {
           _navigationHelper.OpenAuthPage();
            _loginHelper.Login(new AccountData("admin", "secret"));
            InitContactCreation();
            FillContactForm(new ContactData("Stepan", "Stepanov"));
            SubmitContactCreation();
            _navigationHelper.ReturnToHomePage();
            LogOut();
        }
    }
}