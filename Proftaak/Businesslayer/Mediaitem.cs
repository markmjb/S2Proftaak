using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace Businesslayer
{
    
    public class Mediaitem
    {
        DbMedia dbm = new DbMedia();
        public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string filepath { get; set; }

        public string Category { get; set; }

        public int UserID { get; set; }

        public int CategoryID { get; set; }

        public int size { get; set; }

        public Mediaitem(string Type, string Title, string Description, string filepath, int CategoryID, int UserID, int size, string Filetype)
        {
            this.Type = Type;
            this.Title = Title;
            this.Description = Description;
            this.CategoryID = CategoryID;
            this.UserID = UserID;
            this.size = size;
            this.filepath = filepath;

            dbm.AddMediaItem(Title, Description, UserID, size);
            dbm.AddMediaItemFile(filepath, size, Filetype, 2);

        }

    }
}
