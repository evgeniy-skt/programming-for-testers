using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBookWebTests
{
    [TestFixture]
    public class CreateContactTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:8080/addressbook/index.php";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void CreateContactTest()
        {
            OpenAuthPage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            FillContactForm(new ContactData("Stepan", "Stepanov"));
            SubmitContactCreation();
            ReturnToHomePage();
            LogOut();
        }

        private void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }

        private void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        private void OpenAuthPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }

                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}