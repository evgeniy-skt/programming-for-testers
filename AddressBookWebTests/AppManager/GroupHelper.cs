using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class GroupHelper : HelperBase
    {
        private readonly ApplicationManager _manager;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            _manager = manager;
        }

        public GroupHelper Create(GroupData group)
        {
            _manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(@group);
            SubmitGroupCreation();
            _manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int i)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            _manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        private void InitGroupCreation()
        {
            Driver.FindElement(By.Name("new")).Click();
        }

        private void FillGroupForm(GroupData @group)
        {
            Driver.FindElement(By.Name("group_name")).Click();
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        private void SubmitGroupCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }

        private void SelectGroup(int index)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
        }

        private void DeleteGroup()
        {
            Driver.FindElement(By.Name("delete")).Click();
        }
    }
}