using System;
using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class ContactHelper : HelperBase
    {
        private static ApplicationManager _applicationManager;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            _applicationManager = manager;
        }

        public void Create(ContactData contact)
        {
            _applicationManager.Navigator.ReturnToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            _applicationManager.Navigator.ReturnToHomePage();
        }

        public void CreateIfNotExist(ContactData contact)
        {
            _applicationManager.Navigator.ReturnToHomePage();
            if (IsContactExist())
            {
                return;
            }

            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            _applicationManager.Navigator.ReturnToHomePage();
        }

        public static void Modify(int contactIndex, ContactData newData)
        {
            _applicationManager.Navigator.ReturnToHomePage();
            InitContactModification(contactIndex);
            FillContactForm(newData);
            SubmitContactModification();
            _applicationManager.Navigator.ReturnToHomePage();
        }

        public void Remove(int contactIndex)
        {
            _applicationManager.Navigator.ReturnToHomePage();
            SelectContact(contactIndex);
            DeleteContact();
            AcceptAlert();
            _applicationManager.Navigator.ReturnToHomePage();
        }

        public bool IsContactExist()
        {
            _applicationManager.Navigator.ReturnToHomePage();
            var contactsCount = Driver.FindElement(By.Id("search_count")).Text;
            var result = Int32.Parse(contactsCount);
            return result > 0;
        }

        private static void DeleteContact()
        {
            Driver.FindElement(By.XPath("//*[@id=\"content\"]/form[2]/div[2]/input")).Click();
        }

        private static void SubmitContactModification()
        {
            Driver.FindElement(By.Name("update")).Click();
        }

        private static void SubmitContactCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }

        private static void InitContactCreation()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
        }

        private static void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
        }

        private static void InitContactModification(int index)
        {
            Driver.FindElement(By.XPath($"//*[@id=\"maintable\"]/tbody/tr[{index}]/td[8]/a/img")).Click();
        }

        private static void SelectContact(int index)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
        }

        private static void AcceptAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }
    }
}