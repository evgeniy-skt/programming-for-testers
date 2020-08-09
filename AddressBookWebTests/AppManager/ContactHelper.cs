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
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            _applicationManager.Navigator.ReturnToHomePage();
        }

        public static void Modify(int contactIndex, ContactData newData)
        {
            _applicationManager.Navigator.GoToContactPage();
            InitContactModification(contactIndex);
            FillContactForm(newData);
            SubmitContactModification();
            _applicationManager.Navigator.ReturnToHomePage();
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
            Driver.FindElement(By.Name("firstname")).Click();
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }

        private static void InitContactModification(int index)
        {
            Driver.FindElement(By.CssSelector($"a[href=\"edit.php?id={index}\"]")).Click();
        }
    }
}