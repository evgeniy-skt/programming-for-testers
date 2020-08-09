using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class HelperBase
    {
        protected static IWebDriver Driver;

        protected HelperBase(ApplicationManager manager)
        {
            Driver = manager.Driver;
        }
    }
}