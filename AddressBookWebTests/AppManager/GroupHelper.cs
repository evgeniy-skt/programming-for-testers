using OpenQA.Selenium;

namespace AddressBookWebTests
{
    public class GroupHelper : HelperBase
    {
        private static ApplicationManager _manager;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            _manager = manager;
        }

        public void Create(GroupData group)
        {
            _manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            _manager.Navigator.ReturnToGroupsPage();
        }

        public static void Modify(int groupIndex, GroupData newData)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(groupIndex);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            _manager.Navigator.ReturnToGroupsPage();
        }

        private static void SubmitGroupModification()
        {
            Driver.FindElement(By.Name("update")).Click();
        }

        private static void InitGroupModification()
        {
            Driver.FindElement(By.Name("edit")).Click();
        }

        public void Remove(int groupIndex)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(groupIndex);
            DeleteGroup();
            _manager.Navigator.ReturnToGroupsPage();
        }

        private void InitGroupCreation()
        {
            Driver.FindElement(By.Name("new")).Click();
        }

        private static void FillGroupForm(GroupData @group)
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

        private static void SelectGroup(int index)
        {
            Driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();
        }

        private void DeleteGroup()
        {
            Driver.FindElement(By.Name("delete")).Click();
        }
    }
}