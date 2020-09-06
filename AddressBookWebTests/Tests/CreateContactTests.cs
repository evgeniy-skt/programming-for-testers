using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            var groups = new List<ContactData>();
            for (var i = 0; i < 5; i++)
            {
                groups.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    HomeAddress = GenerateRandomString(120),
                    Email = GenerateRandomString(12),
                    Email2 = GenerateRandomString(13),
                    Email3 = GenerateRandomString(14),
                    HomePhone = GenerateRandomString(11),
                    WorkPhone = GenerateRandomString(11),
                    MobilePhone = GenerateRandomString(11)
                });
            }

            return groups;
        }

        [Test, TestCaseSource(nameof(RandomContactDataProvider))]
        public void CreateContactTest(ContactData contact)
        {
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