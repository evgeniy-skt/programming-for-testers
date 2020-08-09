using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;

        protected HelperBase(ApplicationManager manager)
        {
            Driver = manager.Driver;
        }
    }
}