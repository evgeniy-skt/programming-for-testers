using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBookWebTests
{
    public class ApplicationManager
    {
        private readonly string _baseUrl;

        public ApplicationManager()
        {
            Driver = new ChromeDriver();
            _baseUrl = "http://localhost:8080/addressbook/index.php";

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, _baseUrl);
            Group = new GroupHelper(this);
            Contact = new ContactHelper(this);
        }

        public LoginHelper Auth { get; }

        public NavigationHelper Navigator { get; }

        public GroupHelper Group { get; }

        public ContactHelper Contact { get; }

        public IWebDriver Driver { get; }

        public void Stop()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}