using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseUrl;

        public NavigationHelper(IWebDriver driver, string baseUrl) : base(driver)
        {
            _baseUrl = baseUrl;
        }

        public void OpenAuthPage()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        public void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            _driver.FindElement(By.LinkText("home page")).Click();
        }

        public void ReturnToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}