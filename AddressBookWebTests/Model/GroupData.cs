namespace AddressBookWebTests
{
    public class GroupData
    {
        // public string name;
        // public string header = "";
        // public string footer = "";
        public string Name { get; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public GroupData(string name)
        {
            Name = name;
        }
    }
}