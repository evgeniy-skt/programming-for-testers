using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveContactTests : AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            _applicationManager.Contact.Remove(1);
        }
    }
}