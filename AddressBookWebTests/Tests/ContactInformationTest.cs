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

            var contactFromFormWithRightFromat = AllDataFormatter(fromForm);

            Assert.AreEqual(fromDetailInfo, contactFromFormWithRightFromat);
            Assert.AreEqual(fromDetailInfo.AllData, contactFromFormWithRightFromat.AllData);
        }

        public static ContactData AllDataFormatter(ContactData fromForm)
        {
            var resultedString = new ContactData(fromForm.FirstName, fromForm.LastName)
            {
                AllData = fromForm.FirstName + " " + fromForm.LastName
            };
            if (!string.IsNullOrEmpty(fromForm.HomeAddress))
            {
                resultedString.AllData = resultedString.AllData + "\n" + fromForm.HomeAddress + "\n";
            }

            if (!string.IsNullOrEmpty(fromForm.HomePhone))
            {
                resultedString.AllData = resultedString.AllData + "\n" + "H: " + fromForm.HomePhone;
            }

            if (!string.IsNullOrEmpty(fromForm.MobilePhone))
            {
                resultedString.AllData = resultedString.AllData + "\n" + "M: " + fromForm.MobilePhone;
            }

            if (!string.IsNullOrEmpty(fromForm.WorkPhone))
            {
                resultedString.AllData = resultedString.AllData + "\n" + "W: " + fromForm.WorkPhone;
            }

            if (string.IsNullOrEmpty(fromForm.HomePhone) && string.IsNullOrEmpty(fromForm.MobilePhone) &&
                string.IsNullOrEmpty(fromForm.WorkPhone))
            {
                if (!string.IsNullOrEmpty(fromForm.Email) || !string.IsNullOrEmpty(fromForm.Email2) ||
                    !string.IsNullOrEmpty(fromForm.Email3))
                {
                    resultedString.AllData = resultedString.AllData + "\n" + fromForm.AllEmails;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(fromForm.Email) || !string.IsNullOrEmpty(fromForm.Email2) ||
                    !string.IsNullOrEmpty(fromForm.Email3))
                {
                    resultedString.AllData = resultedString.AllData + "\n\n" + fromForm.AllEmails;
                }
            }

            return resultedString;
        }
    }
}