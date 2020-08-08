using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {
        [Test]
        public void CreateContactTest()
        {
            OpenAuthPage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            FillContactForm(new ContactData("Stepan", "Stepanov"));
            SubmitContactCreation();
            ReturnToHomePage();
            LogOut();
        }
    }
}