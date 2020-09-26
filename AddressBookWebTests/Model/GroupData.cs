using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace AddressBookWebTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name = "group_name")] public string Name { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "group_header")] public string Header { get; set; }
        [Column(Name = "group_footer")] public string Footer { get; set; }

        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData()
        {
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "Name = " + Name + "\n header = " + Header + "\n footer = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAll()
        {
            DataConnection.DefaultSettings = new MySettings();
            var db = new AddressBookDb();
            var fromDB = (from g in db.Groups select g).ToList();
            db.Close();
            return fromDB;
        }

        public List<ContactData> GetContacts()
        {
            DataConnection.DefaultSettings = new MySettings();
            var db = new AddressBookDb();
            return (from c in db.Contacts
                from groupContactRelation in db.GroupContactRelation.Where(p =>
                    p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                select c).Distinct().ToList();
        }
    }
}