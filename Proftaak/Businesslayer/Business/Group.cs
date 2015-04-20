using System.Collections.Generic;

namespace Businesslayer.Business
{
    public class Group
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public Group()
        {
            
        }

        public Group(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public Group(string groupname)
        {
            Name = groupname;
        }
    }
}
