using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            var fromTable = _applicationManager.Contact.GetContactInfoFromTable(0);
            var fromFrom = _applicationManager.Contact.GetContactInfoFromEditForm(0);

            Assert.AreEqual(fromTable, fromFrom);
            Assert.AreEqual(fromTable.HomeAddress, fromFrom.HomeAddress);
            Assert.AreEqual(fromTable.AllPhones, fromFrom.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromFrom.AllEmails);
        }

        [Test]
        public void DetailContactInformationTest()
        {
            var fromForm = _applicationManager.Contact.GetContactInfoFromEditForm(0);
            var fromDetailInfo = _applicationManager.Contact.GetContactInfoFromDetailInfo();

            Assert.AreEqual(fromDetailInfo, fromForm);
            Assert.AreEqual(fromDetailInfo.AllData, fromForm.AllData);
        }
    }
}