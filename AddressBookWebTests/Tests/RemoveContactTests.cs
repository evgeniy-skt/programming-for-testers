using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveContactTests : TestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            _applicationManager.Contact.Remove(1);
        }
    }
}