using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ModificationGroupTests : TestBase
    {
        [Test]
        public void ModificationGroupTest()
        {
            var newData = new GroupData("Edited name") {Header = "Edited header", Footer = "Edited footer"};
            GroupHelper.Modify(1, newData);
        }
    }
}