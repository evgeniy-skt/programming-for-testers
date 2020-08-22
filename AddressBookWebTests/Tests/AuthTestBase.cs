using NUnit.Framework;

namespace AddressBookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            _applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}