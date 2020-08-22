using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            _baseUrl = baseUrl;
        }

        public void OpenAuthPage()
        {
            if (Driver.Url == _baseUrl + "index.php")
            {
                return;
            }

            Driver.Navigate().GoToUrl(_baseUrl);
        }

        public void GoToGroupsPage()
        {
            if (Driver.Url == _baseUrl + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }

            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            if (Driver.Url == _baseUrl + "index.php")
            {
                return;
            }

            Driver.FindElement(By.LinkText("home")).Click();
        }

        public void ReturnToGroupsPage()
        {
            if (Driver.Url == _baseUrl + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }

            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {
            if (Driver.Url == _baseUrl + "index.php")
            {
                return;
            }

            Driver.FindElement(By.LinkText("home")).Click();
        }
    }
}