using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        public static IEnumerable<ContactData> GroupDataFromXMLFile()
        {
            return (List<ContactData>) new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> GroupDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            var groups = new List<ContactData>();
            for (var i = 0; i < 5; i++)
            {
                groups.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    HomeAddress = "Lenyna str, 25b, 15ap",
                    MobilePhone = "+79091234567",
                    HomePhone = "+74951234567",
                    WorkPhone = "+74957654321",
                    Email = "ivanov@mail.ru",
                    Email2 = "ivan@mail.ru",
                    Email3 = "ivanovich@mail.ru",
                });
            }

            return groups;
        }

        [Test, TestCaseSource(nameof(GroupDataFromJSONFile))]
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