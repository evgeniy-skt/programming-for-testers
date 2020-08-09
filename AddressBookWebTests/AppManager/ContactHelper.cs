using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper SubmitContactCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Driver.FindElement(By.Name("firstname")).Click();
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }
    }
}