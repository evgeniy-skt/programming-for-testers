using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBookWebTests
{
    public class TestBase
    {
        private IWebDriver Driver;
        private StringBuilder _verificationErrors;
        private string BaseUrl;

        [SetUp]
        public void SetupTest()
        {
            Driver = new ChromeDriver();
            BaseUrl = "http://localhost:8080/addressbook/index.php";
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", _verificationErrors.ToString());
        }

        protected void OpenAuthPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        protected void Login(AccountData account)
        {
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            Driver.FindElement(By.Name("pass")).Clear();
            Driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            Driver.FindElement(By.Id("LoginForm")).Submit();
        }

        protected void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void InitGroupCreation()
        {
            Driver.FindElement(By.Name("new")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            Driver.FindElement(By.Name("group_name")).Click();
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void SubmitGroupCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }

        protected void ReturnToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void SelectGroup(int index)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
        }

        protected void DeleteGroup()
        {
            Driver.FindElement(By.Name("delete")).Click();
        }

        protected void LogOut()
        {
            Driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}