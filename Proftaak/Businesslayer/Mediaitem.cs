using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class Mediaitem
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int UserID { get; set; }

        public Mediaitem(string Type, string Title, string Description, string Category, int UserID)
        {
            this.Type = Type;
            this.Title = Title;
            this.Description = Description;
            this.Category = Category;
            this.UserID = UserID;

        }

    }
}
