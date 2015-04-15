using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class MediaItemData
    {
        public int MediaitemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }



        public MediaItemData(int mediaitemID ,string title, string description, int userid)
        {
            this.MediaitemID = mediaitemID;
            this.Title = title;
            this.Description = description;
            this.UserID = userid;

           

        }

       
    }
}
