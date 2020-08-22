using NUnit.Framework;

namespace AddressBookWebTests
{
    public class LoginTest
    {
        [TestFixture]
        public class LoginTests : TestBase
        {
            [Test]
            public void LoginWithValidCredentials()
            {
                _applicationManager.Auth.Logout();

                var account = new AccountData("admin", "secret");
                _applicationManager.Auth.Login(account);

                Assert.IsTrue(_applicationManager.Auth.IsLoggedIn(account));
            }

            [Test]
            public void LoginWithInValidCredentials()
            {
                _applicationManager.Auth.Logout();

                var account = new AccountData("admin", "secretsecret");
                _applicationManager.Auth.Login(account);

                Assert.IsFalse(_applicationManager.Auth.IsLoggedIn(account));
            }
        }
    }
}