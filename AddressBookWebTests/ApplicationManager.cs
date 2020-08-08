using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBookWebTests
{
    public class ApplicationManager
    {
        private readonly IWebDriver _driver;
        private string _baseUrl;

        public ApplicationManager()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://localhost:8080/addressbook/index.php";

            Auth = new LoginHelper(_driver);
            Navigator = new NavigationHelper(_driver, _baseUrl);
            Group = new GroupHelper(_driver);
            Contact = new ContactHelper(_driver);
        }

        public LoginHelper Auth { get; }

        public NavigationHelper Navigator { get; }

        public GroupHelper Group { get; }

        public ContactHelper Contact { get; }

        public void Stop()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}