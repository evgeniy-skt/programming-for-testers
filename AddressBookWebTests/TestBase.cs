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
        }

        [TearDown]
        public void TeardownTest()
        {
            _applicationManager.Stop();
        }



    }
}