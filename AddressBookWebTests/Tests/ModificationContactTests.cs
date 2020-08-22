using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ModificationContactTests : AuthTestBase
    {
        [Test]
        public void ModificationContactTest()
        {
            var newData = new ContactData("Stepan", "Gogoidze");
            ContactHelper.Modify(2, newData);
        }
    }
}