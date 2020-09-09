using AddressBookWebTests;
using NUnit.Framework;

namespace AddressBookWebTestsUnitTests
{
    public class Tests
    {
        [Test]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "asfd", "asdf", "afsd")]
        public void WhenAllFeildsAreNotEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +3324523\nM: +3424523\nW: +34252\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "asfd", "asdf", "")]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "", "asfd", "asdf")]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "asfd", "", "asdf")]
        public void WhenOneOfEmailsFieldIsEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone, string workPhone, string email, string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +3324523\nM: +3424523\nW: +34252\n\nasfd\nasdf"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "asfd", "", "")]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "", "asfd", "")]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "", "", "asfd")]
        public void WhenTwoOfEmailFieldsAreEmptyShouldReturnCorrectString(string homeAddress,
            string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +3324523\nM: +3424523\nW: +34252\n\nasfd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "+3324523", "+3424523", "+34252", "", "", "")]
        public void WhenAllEmailsFieldsAreEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +3324523\nM: +3424523\nW: +34252"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }


        [Test]
        [TestCase("dsfjlk dsfkjl", "", "", "", "asfd", "asdf", "afsd")]
        public void WhenAllPhonesFieldsAreEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "", "+33245239", "+3424523", "asfd", "asdf", "afsd")]
        public void WhenHomePhoneFieldIsEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nM: +33245239\nW: +3424523\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "+33245239", "", "+3424523", "asfd", "asdf", "afsd")]
        public void WhenMobilePhoneFieldIsEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +33245239\nW: +3424523\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "+33245239", "+3424523", "", "asfd", "asdf", "afsd")]
        public void WhenWorkPhoneFieldIsEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +33245239\nM: +3424523\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "", "", "+3424523", "asfd", "asdf", "afsd")]
        public void WhenHomeAndMobilePhoneFieldsAreEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nW: +3424523\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "+3424523", "", "", "asfd", "asdf", "afsd")]
        public void WhenMobileAndWorkPhoneFieldsAreEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nH: +3424523\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }

        [Test]
        [TestCase("dsfjlk dsfkjl", "", "+3424523", "", "asfd", "asdf", "afsd")]
        public void WhenHomeAndWorkPhoneFieldsAreEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\ndsfjlk dsfkjl\n\nM: +3424523\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }


        [Test]
        [TestCase("", "+3324523", "+3424523", "+34252", "asfd", "asdf", "afsd")]
        public void WhenAddressFieldIsEmptyShouldReturnCorrectString(string homeAddress, string homePhone,
            string mobilePhone,
            string workPhone, string email,
            string email2, string email3)
        {
            var contact = new ContactData("Stepanov", "Stepan")
            {
                HomeAddress = homeAddress,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                MobilePhone = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllData = "",
            };
            var actualResult = ContactInformationTest.AllDataFormatter(contact);
            var expectedResult = new ContactData("Stepanov", "Stepan")
            {
                AllData = "Stepanov Stepan\nH: +3324523\nM: +3424523\nW: +34252\n\nasfd\nasdf\nafsd"
            };
            Assert.AreEqual(expectedResult.AllData, actualResult.AllData);
        }
    }
}