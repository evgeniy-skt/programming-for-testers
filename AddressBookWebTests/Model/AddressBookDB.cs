using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Configuration;

namespace AddressBookWebTests
{
    public class AddressBookDb : LinqToDB.Data.DataConnection
    {
        public AddressBookDb() : base("AddressBook")
        {
        }

        public ITable<GroupData> Groups => GetTable<GroupData>();
        public ITable<ContactData> Contacts => GetTable<ContactData>();
    }

    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
        {
            get { yield break; }
        }

        public string DefaultConfiguration => "AddressBook";
        public string DefaultDataProvider => ProviderName.MySql;

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "AddressBook",
                        ProviderName = "MySql.Data.MySqlClient",
                        ConnectionString =
                            @"Server=192.168.64.2;Port=3306;Database=addressbook;Uid=evgeniy;Pwd=dodo2015;Allow Zero Datetime = True;Connection Timeout=35"
                    };
            }
        }
    }
}