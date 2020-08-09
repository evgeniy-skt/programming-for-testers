using NUnit.Framework;

namespace AddressBookWebTests
{
    public class TestBase
    {
        protected ApplicationManager _applicationManager;

        [SetUp]
        public void SetupTest()
        {
            _applicationManager = new ApplicationManager();
            _applicationManager.Navigator.OpenAuthPage();
            _applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            _applicationManager.Stop();
        }
    }
}