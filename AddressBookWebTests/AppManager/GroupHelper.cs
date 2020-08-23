using System.Collections.Generic;
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

        public void CreateIfNotExist(GroupData group)
        {
            _manager.Navigator.GoToGroupsPage();
            if (IsGroupExist())
            {
                return;
            }

            _manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            _manager.Navigator.ReturnToGroupsPage();
        }

        public void Modify(int groupIndex, GroupData newData)
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
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
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

        public bool IsGroupExist()
        {
            return Driver.FindElements(By.ClassName("group")).Count > 0;
        }

        public List<GroupData> GetGroupsList()
        {
            var groups = new List<GroupData>();

            _manager.Navigator.GoToGroupsPage();

            var elements = Driver.FindElements(By.CssSelector("span.group"));
            foreach (var element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }
    }
}