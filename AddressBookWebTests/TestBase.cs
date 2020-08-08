using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBookWebTests
{
    public class TestBase
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        protected LoginHelper _loginHelper;
        protected NavigationHelper _navigationHelper;

        [SetUp]
        public void SetupTest()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost:8080/addressbook/index.php";
            _verificationErrors = new StringBuilder();

            _loginHelper = new LoginHelper(_driver);
            _navigationHelper = new NavigationHelper(_driver, _baseUrl);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", _verificationErrors.ToString());
        }

        protected void InitGroupCreation()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).Click();
            _driver.FindElement(By.Name("group_name")).Clear();
            _driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            _driver.FindElement(By.Name("group_header")).Clear();
            _driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            _driver.FindElement(By.Name("group_footer")).Clear();
            _driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void SubmitGroupCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        protected void SelectGroup(int index)
        {
            _driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
        }

        protected void DeleteGroup()
        {
            _driver.FindElement(By.Name("delete")).Click();
        }

        protected void InitContactCreation()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void FillContactForm(ContactData contact)
        {
            _driver.FindElement(By.Name("firstname")).Click();
            _driver.FindElement(By.Name("firstname")).Clear();
            _driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _driver.FindElement(By.Name("lastname")).Clear();
            _driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }

        protected void SubmitContactCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        protected void LogOut()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}