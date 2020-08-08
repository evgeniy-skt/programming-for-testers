using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class LoginHelper
    {
        private readonly IWebDriver _driver;

        public LoginHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _driver.FindElement(By.Id("LoginForm")).Submit();
        }
    }
}