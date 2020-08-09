using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class RemoveGroupTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            _applicationManager.Group.Remove(1);
        }
    }
}