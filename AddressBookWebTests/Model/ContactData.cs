using System;

namespace AddressBookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string CompanyAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string FaxPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string HomePage { get; set; }
        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string Group { get; set; }
        public string HomeAddress { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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
            return "FirstName " + FirstName + ";" + "LastName " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return FirstName.CompareTo(other.FirstName);
        }
    }
}