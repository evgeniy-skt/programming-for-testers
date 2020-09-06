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
            if (string.IsNullOrEmpty(fromForm.HomeAddress))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + "H: " + fromForm.HomePhone + "\n" +
                              "M: " + fromForm.MobilePhone + "\n" + "W: " + fromForm.WorkPhone + "\n\n" +
                              fromForm.Email + "\n" + fromForm.Email2 + "\n" + fromForm.Email3,
                };
            }

            if (string.IsNullOrEmpty(fromForm.HomePhone) && string.IsNullOrEmpty(fromForm.MobilePhone) &&
                string.IsNullOrEmpty(fromForm.WorkPhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              fromForm.Email + "\n" + fromForm.Email2 + "\n" + fromForm.Email3,
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email) && string.IsNullOrEmpty(fromForm.Email2) &&
                string.IsNullOrEmpty(fromForm.Email3))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone
                };
            }

            if (string.IsNullOrEmpty(fromForm.HomePhone) && string.IsNullOrEmpty(fromForm.MobilePhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "W: " + fromForm.WorkPhone + "\n\n" + fromForm.Email + "\n" + fromForm.Email2 + "\n" +
                              fromForm.Email3,
                };
            }

            if (string.IsNullOrEmpty(fromForm.MobilePhone) && string.IsNullOrEmpty(fromForm.WorkPhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " + fromForm.HomePhone + "\n\n" + fromForm.Email + "\n" + fromForm.Email2 +
                              "\n" + fromForm.Email3,
                };
            }

            if (string.IsNullOrEmpty(fromForm.HomePhone) && string.IsNullOrEmpty(fromForm.WorkPhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "M: " + fromForm.MobilePhone + "\n\n" + fromForm.Email + "\n" + fromForm.Email2 +
                              "\n" + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.HomePhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "M: " + fromForm.MobilePhone + "\n" + "W: " + fromForm.WorkPhone + "\n\n" +
                              fromForm.Email + "\n" + fromForm.Email2 + "\n" + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.MobilePhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " + fromForm.HomePhone + "\n" + "W: " + fromForm.WorkPhone + "\n\n" +
                              fromForm.Email + "\n" + fromForm.Email2 + "\n" + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.WorkPhone))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " + fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n\n" +
                              fromForm.Email + "\n" + fromForm.Email2 + "\n" + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email) && string.IsNullOrEmpty(fromForm.Email2))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone +
                              "\n\n" + fromForm.Email + fromForm.Email2 + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email2) && string.IsNullOrEmpty(fromForm.Email3))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone +
                              "\n\n" + fromForm.Email + fromForm.Email2 + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email) && string.IsNullOrEmpty(fromForm.Email3))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone +
                              "\n\n" + fromForm.Email + fromForm.Email2 + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone +
                              "\n\n" + fromForm.Email2 + "\n" + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email2))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone +
                              "\n\n" + fromForm.Email + "\n" + fromForm.Email3
                };
            }

            if (string.IsNullOrEmpty(fromForm.Email3))
            {
                return new ContactData(fromForm.FirstName, fromForm.LastName)
                {
                    AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                              "H: " +
                              fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                              fromForm.WorkPhone +
                              "\n\n" + fromForm.Email + "\n" + fromForm.Email2
                };
            }

            return new ContactData(fromForm.FirstName, fromForm.LastName)
            {
                AllData = fromForm.FirstName + " " + fromForm.LastName + "\n" + fromForm.HomeAddress + "\n\n" +
                          "H: " +
                          fromForm.HomePhone + "\n" + "M: " + fromForm.MobilePhone + "\n" + "W: " +
                          fromForm.WorkPhone +
                          "\n\n" + fromForm.Email + "\n" + fromForm.Email2 + "\n" + fromForm.Email3,
            };
        }
    }
}