using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            Driver.FindElement(By.Name("pass")).Clear();
            Driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            Driver.FindElement(By.Id("LoginForm")).Submit();
        }
    }
}