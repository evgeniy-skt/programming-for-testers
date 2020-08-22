using NUnit.Framework;

namespace AddressBookWebTests
{
    public class TestBase
    {
        protected ApplicationManager _applicationManager;

        [SetUp]
        public void SetupTest()
        {
            _applicationManager = ApplicationManager.GetInstance();
        }
    }
}