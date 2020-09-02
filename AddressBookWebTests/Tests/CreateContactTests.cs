using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        [Test]
        public void CreateContactTest()
        {
            var contact = new ContactData("Gogi", "Stepanidze")
            {
                HomeAddress = "Lenyna str, 25b, 15ap",
                MobilePhone = "+79091234567",
                HomePhone = "+74951234567",
                WorkPhone = "+74957654321",
                Email = "ivanov@mail.ru",
                Email2 = "ivan@mail.ru",
                Email3 = "ivanovich@mail.ru",
            };
            var oldContacts = _applicationManager.Contact.GetContactList();

            _applicationManager.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, _applicationManager.Contact.GetGroupsListCount());

            var newContacts = _applicationManager.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}