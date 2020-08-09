using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            _driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            _driver.FindElement(By.Name("group_name")).Click();
            _driver.FindElement(By.Name("group_name")).Clear();
            _driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            _driver.FindElement(By.Name("group_header")).Clear();
            _driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            _driver.FindElement(By.Name("group_footer")).Clear();
            _driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            _driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            _driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            _driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}