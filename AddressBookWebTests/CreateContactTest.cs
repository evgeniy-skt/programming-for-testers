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
            _contactHelper.InitContactCreation();
            _contactHelper.FillContactForm(new ContactData("Stepan", "Stepanov"));
            _contactHelper.SubmitContactCreation();
            _navigationHelper.ReturnToHomePage();
            LogOut();
        }
    }
}