using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    class Group
    {
        public List<User> GroupMembers { get; set; }
        public string Name { get; set; }

        public Group(List<User> groupMembers, string name)
        {
            GroupMembers = groupMembers;
            Name = name;
        }
    }
}
