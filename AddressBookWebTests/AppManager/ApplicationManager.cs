using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AddressBookWebTests
{
    public class ApplicationManager
    {
        private readonly string _baseUrl;
        private static ThreadLocal<ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            Driver = new ChromeDriver();
            _baseUrl = "http://localhost:8080/addressbook/index.php";

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, _baseUrl);
            Group = new GroupHelper(this);
            Contact = new ContactHelper(this);
        }

        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (!applicationManager.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance.Navigator.OpenAuthPage();
                applicationManager.Value = newInstance;
            }

            return applicationManager.Value;
        }

        public LoginHelper Auth { get; }

        public NavigationHelper Navigator { get; }

        public GroupHelper Group { get; }

        public ContactHelper Contact { get; }

        public IWebDriver Driver { get; }
    }
}