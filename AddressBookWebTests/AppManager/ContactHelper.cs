using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class ContactHelper : HelperBase
    {
        private static ApplicationManager _applicationManager;
        private static List<ContactData> _contactCache;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            _applicationManager = manager;
        }

        public void Create(ContactData contact)
        {
            _applicationManager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            _applicationManager.Navigator.GoToHomePage();
        }

        public void CreateIfNotExist(ContactData contact)
        {
            _applicationManager.Navigator.GoToHomePage();
            if (IsContactExist())
            {
                return;
            }

            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            _applicationManager.Navigator.GoToHomePage();
        }

        public static void Modify(int contactIndex, ContactData newData)
        {
            _applicationManager.Navigator.GoToHomePage();
            InitContactModification(contactIndex);
            FillContactForm(newData);
            SubmitContactModification();
            _applicationManager.Navigator.GoToHomePage();
        }

        public void Remove(int contactIndex)
        {
            _applicationManager.Navigator.GoToHomePage();
            SelectContact(contactIndex);
            DeleteContact();
            AcceptAlert();
            _applicationManager.Navigator.GoToHomePage();
        }

        public bool IsContactExist()
        {
            return Driver.FindElements(By.Name("entry")).Count > 0;
        }

        private static void DeleteContact()
        {
            Driver.FindElement(By.XPath("//*[@id=\"content\"]/form[2]/div[2]/input")).Click();
            _contactCache = null;
        }

        private static void SubmitContactModification()
        {
            Driver.FindElement(By.Name("update")).Click();
            _contactCache = null;
        }

        private static void SubmitContactCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
            _contactCache = null;
        }

        private static void InitContactCreation()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
        }

        private static void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("address"), contact.HomeAddress);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
        }

        private static void InitContactModification(int index)
        {
            Driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a"))
                .Click();
        }

        private static void SelectContact(int index)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index + 1}]")).Click();
        }

        private static void AcceptAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        public List<ContactData> GetContactList()
        {
            if (_contactCache == null)
            {
                _applicationManager.Navigator.GoToContactPage();
                _contactCache = new List<ContactData>();

                var elements = Driver.FindElements(By.Name("entry"));

                foreach (var element in elements)
                {
                    var cells = element.FindElements(By.TagName("td")).ToList();
                    _contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                        {Id = element.FindElement(By.TagName("input")).GetAttribute("id")});
                }
            }

            return _contactCache;
        }

        public int GetGroupsListCount()
        {
            return Driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInfoFromTable(int index)
        {
            _applicationManager.Navigator.GoToHomePage();
            var cells = Driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            var lastName = cells[1].Text;
            var firstName = cells[2].Text;
            var address = cells[3].Text;
            var allPhones = cells[5].Text;
            var emails = cells[6].Text;
            return new ContactData(firstName, lastName)
            {
                HomeAddress = address,
                AllPhones = allPhones,
                AllEmails = emails,
            };
        }

        public ContactData GetContactInfoFromEditForm(int index)
        {
            _applicationManager.Navigator.GoToHomePage();
            InitContactModification(0);
            var firstName = Driver.FindElement(By.Name("firstname")).GetAttribute("value");
            var lastName = Driver.FindElement(By.Name("lastname")).GetAttribute("value");
            var address = Driver.FindElement(By.Name("address")).GetAttribute("value");
            var homePhone = Driver.FindElement(By.Name("home")).GetAttribute("value");
            var mobilePhone = Driver.FindElement(By.Name("mobile")).GetAttribute("value");
            var workPhone = Driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                HomeAddress = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
            };
        }

        public int GetNumberOfSearchResult()
        {
            _applicationManager.Navigator.GoToHomePage();
            var text = Driver.FindElement(By.TagName("label")).Text;
            var match = new Regex(@"\d+").Match(text);
            return Int32.Parse(match.Value);
        }
    }
}