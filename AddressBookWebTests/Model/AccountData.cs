namespace AddressBookWebTests
{
    public class AccountData
    {
        public string UserName { get; }
        public string Password { get; }

        public AccountData(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}