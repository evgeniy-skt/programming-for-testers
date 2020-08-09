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
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        public void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            Driver.FindElement(By.LinkText("home page")).Click();
        }

        public void ReturnToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {
            Driver.FindElement(By.LinkText("home")).Click();
        }
    }
}