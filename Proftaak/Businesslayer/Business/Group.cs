using System.Collections.Generic;

namespace Businesslayer.Business
{
    public class Group
    {
        public List<User> GroupMembers { get; set; }
        public string Name { get; set; }

        public Group(List<User> groupMembers, string name)
        {
            GroupMembers = groupMembers;
            Name = name;
        }

        public Group(string name)
        {
            Name = name;
        }
    }
}
