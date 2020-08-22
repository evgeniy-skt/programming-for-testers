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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("user"), account.UserName);
            Type(By.Name("pass"), account.Password);
            Driver.FindElement(By.Id("LoginForm")).Submit();
        }

        private bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && Driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text ==
                "(" + account.UserName + ")";
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                Driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}