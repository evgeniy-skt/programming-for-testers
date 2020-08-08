using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitContactCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        public void InitContactCreation()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillContactForm(ContactData contact)
        {
            _driver.FindElement(By.Name("firstname")).Click();
            _driver.FindElement(By.Name("firstname")).Clear();
            _driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _driver.FindElement(By.Name("lastname")).Clear();
            _driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }
    }
}