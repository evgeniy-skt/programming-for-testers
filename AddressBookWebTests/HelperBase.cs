using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class HelperBase
    {
        protected readonly IWebDriver _driver;

        protected HelperBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}