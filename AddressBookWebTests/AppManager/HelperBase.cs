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

        protected static void Type(By locator, string text)
        {
            if (text != null)
            {
                Driver.FindElement(locator).Clear();
                Driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}