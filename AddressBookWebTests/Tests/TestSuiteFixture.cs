using NUnit.Framework;

namespace AddressBookWebTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [OneTimeSetUp]
        public void StartApplicationManager()
        {
            var applicationManager = ApplicationManager.GetInstance();
            applicationManager.Navigator.OpenAuthPage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}