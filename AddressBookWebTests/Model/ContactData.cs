using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace AddressBookWebTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _allData;
        private string _allEmails;
        [Column(Name = "firstname")] public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Column(Name = "lastname")] public string LastName { get; set; }
        public string Nick { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string CompanyAddress { get; set; }
        [Column(Name = "home")] public string HomePhone { get; set; }
        [Column(Name = "mobile")] public string MobilePhone { get; set; }
        [Column(Name = "work")] public string WorkPhone { get; set; }
        public string FaxPhone { get; set; }
        [Column(Name = "email")] public string Email { get; set; }
        [Column(Name = "email2")] public string Email2 { get; set; }
        [Column(Name = "email3")] public string Email3 { get; set; }
        public string HomePage { get; set; }
        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string Group { get; set; }
        [Column(Name = "address")] public string HomeAddress { get; set; }
        public string Notes { get; set; }
        [Column(Name = "id")] public string Id { get; set; }

        public string AllPhones
        {
            get
            {
                if (_allPhones != null || _allPhones == "")
                {
                    return _allPhones;
                }

                return (PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone)).Trim();
            }
            set => _allPhones = value;
        }

        public string AllEmails
        {
            get
            {
                if (_allEmails != null || _allEmails == "")
                {
                    return _allEmails;
                }

                return (EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3)).Trim();
            }
            set => _allEmails = value;
        }

        public string AllData
        {
            get
            {
                if (_allData != null || _allData == "")
                {
                    return _allData;
                }

                return (PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone)).Trim() +
                       (EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3)).Trim();
            }
            set => _allData = value;
        }

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private string PhoneCleanUp(string phone)
        {
            return string.IsNullOrEmpty(phone)
                ? ""
                : Regex.Replace(phone, "[ -()]", "") + "\n";
        }

        private string EmailCleanUp(string email)
        {
            return string.IsNullOrEmpty(email)
                ? ""
                : Regex.Replace(email, "[ ]", "") + "\n";
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            //todo поменять местами параметры
            return "FirstName " + FirstName + ";" + "LastName " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);
        }

        public static List<ContactData> GetAll()
        {
            DataConnection.DefaultSettings = new MySettings();
            var db = new AddressBookDb();
            var fromDB = (from c in db.Contacts select c).ToList();
            db.Close();
            return fromDB;
        }
    }
}