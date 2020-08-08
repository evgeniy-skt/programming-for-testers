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
        protected GroupHelper _groupHelper;
        protected ContactHelper _contactHelper;

        [SetUp]
        public void SetupTest()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost:8080/addressbook/index.php";
            _verificationErrors = new StringBuilder();

            _loginHelper = new LoginHelper(_driver);
            _navigationHelper = new NavigationHelper(_driver, _baseUrl);
            _groupHelper = new GroupHelper(_driver);
            _contactHelper = new ContactHelper(_driver);
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


        protected void LogOut()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}