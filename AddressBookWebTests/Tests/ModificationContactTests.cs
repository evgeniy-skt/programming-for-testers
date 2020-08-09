using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ModificationContactTests : TestBase
    {
        [Test]
        public void ModificationContactTest()
        {
            var newData = new ContactData("Stepan", "Gogoidze");
            ContactHelper.Modify(2, newData);
        }
    }
}