using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    
    public class Mediaitem
    {
        DbMedia dbm = new DbMedia();

        public int Mediacategoryofid { get; set; }
        
        public string Filetype { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Filepath { get; set; }

        public string Category { get; set; }

        public int UserID { get; set; }

        public int CategoryID { get; set; }

        public int Filesize { get; set; }

        public int Mediaitemid { get; set; }

        public string Text { get; set; }
        public int Likeid { get; set; }
        public int MediaitemcommentID { get; set; }

        public int Mediacategoryid { get; set; }




        public Mediaitem(string Type, string Title, string Description, string filepath, int CategoryID, int UserID, int size, string Filetype)
        {
            this.Filetype = Type;
            this.Title = Title;
            this.Description = Description;
            this.CategoryID = CategoryID;
            this.UserID = UserID;
            this.Filesize = size;
            this.Filepath = filepath;

            dbm.AddMediaItem(Title, Description, UserID);
            Mediaitemid = dbm.GetMediaItemID(Title);
            dbm.AddMediaItemFile(Mediaitemid,filepath, size, Filetype, 2);
            dbm.Getmediaitems();

        }

        public Mediaitem(int mediaitemid, string title, string description, int userid)
        {
            this.Mediaitemid = mediaitemid;
            this.Title = title;
            this.Description = description;
            this.UserID = userid;

        }

        public Mediaitem(int mediaitemid, string filepath, int filesize, string filetype, int mediacategoryofid)
        {
            this.Mediaitemid = mediaitemid;
            this.Filepath = filepath;
            this.Filesize = filesize;
            this.Filetype = filetype;
            this.Mediacategoryofid = mediacategoryofid;
        }

        public override string ToString()
        {
            return Mediaitemid.ToString() + ":" + Title;
        }
        
        public Mediaitem(int mediaitemid, string text, int mediaitemcommentid)
        {
            this.Mediaitemid = mediaitemid;
            this.Text = text;
            this.MediaitemcommentID= mediaitemcommentid;
        }

        public Mediaitem(int likeid, int userid, int mediaitemid, int mediacategoryid)
        {
            this.Likeid = likeid;
            this.UserID = userid;
            this.Mediaitemid = mediaitemid;
            this.Mediacategoryid = mediacategoryid;
        }

       
        public Mediaitem()
        {
           
        }
    }
         
}
