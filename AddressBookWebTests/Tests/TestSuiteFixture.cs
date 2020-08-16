using NUnit.Framework;

namespace AddressBookWebTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManager applicationManager;

        [OneTimeSetUp]
        public void StartApplicationManager()
        {
            applicationManager = new ApplicationManager();
            applicationManager.Navigator.OpenAuthPage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [OneTimeTearDown]
        public void StopApplicationManager()
        {
            applicationManager.Stop();
        }
    }
}