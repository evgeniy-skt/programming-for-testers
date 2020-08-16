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
            Type(By.Name("user"), account.UserName);
            Type(By.Name("pass"), account.Password);
            Driver.FindElement(By.Id("LoginForm")).Submit();
        }
    }
}