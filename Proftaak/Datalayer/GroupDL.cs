using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class GroupDL
    {       
        public List<UserDL> GroupMembers { get; set; }
        public string Name { get; set; }


        public GroupDL(List<UserDL> groupMembers, string name)
        {
            GroupMembers = groupMembers;
            Name = name;
        }

        public GroupDL(string name)
        {
            Name = name;
        }
    }
}
