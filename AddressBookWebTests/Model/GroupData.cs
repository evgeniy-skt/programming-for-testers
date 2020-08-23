using System;

namespace AddressBookWebTests
{
    public class GroupData : IEquatable<GroupData>
    {
        public string Name { get; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public GroupData(string name)
        {
            Name = name;
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

        public int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}