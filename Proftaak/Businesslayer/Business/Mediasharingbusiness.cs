using System.Collections.Generic;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class Mediasharingbusiness
    {
        private DbMedia dbmedia = new DbMedia();

        public List<Mediaitem> Getallmediaitems()
        {
            List<Mediaitem> mediaitemsbusiness = dbmedia.Getmediaitems();


            return mediaitemsbusiness;
        }

        public List<Mediaitem> SearchOnTitle(string Title)
        {
          


            return dbmedia.SearchOnTitle(Title);
        }

        public List<Mediaitem> SearchOnCategory(string Categorytitle)
        {



            return dbmedia.SearchOnCategory(Categorytitle);
        }

        public int GetUserID(int mediaitemid)
        {
            return dbmedia.GetUserID(mediaitemid);
        }

        public int getcategory(string category)
        {
            return dbmedia.GetCategoryID(category);
        }

        public int GetmediaitemID(string Title)
        {
            return dbmedia.GetMediaItemID(Title);
        }

        public void RemoveMediaItem(Mediaitem mediaitem)
        {
            dbmedia.RemoveMediaItem(mediaitem);
        }


        public void RemoveMediaItemFile(Mediaitem mediaitem)
        {
            dbmedia.RemoveMediaItemFile(mediaitem);
        }

        public void RemoveReply(string mediaitemid)
        {
            dbmedia.RemoveReply(mediaitemid);
        }

        public Mediaitem Getsinglemediaitem(int mediaitemid)
        {
            return dbmedia.Getsinglemediaitem(mediaitemid);
            
        }

        public Mediaitem Getsinglemediaitemfile(int mediaitemid)
        {
            return dbmedia.Getsinglemediaitemfile(mediaitemid);

        }

        public List<Mediaitem> Getmediatextlist(int mediaitemid)
        {
            return dbmedia.Getmediatext(mediaitemid);

        }

        public List<Mediaitem> AlreadyLiked()
        {
            return dbmedia.AlreadyLiked();

        }



        public List<string> GetAllCategories()
        {
        return dbmedia.GetAllCategories();
        }


        public int  GetAllLikes(int mediaitemid)
        {
            return dbmedia.GetAllLikes(mediaitemid);

        }

        public int GetAllLikesReply(int mediacategoryID)
        {
            return dbmedia.GetAllLikesReply(mediacategoryID);

        }

        public void AddLikeToFile(int mediaitemid,int userid)
        {
            dbmedia.AddLikeToFile(mediaitemid, userid);

        }
        public void AddLikeToReply(int mediaitemid,int userid)
        {
            dbmedia.AddLikeToReply(mediaitemid, userid);

        }

        public void AddReport(int mediaitemid, int userid)
        {
            dbmedia.AddReport(mediaitemid, userid);

        }

        public void AddReplytofile(string text, int mediaitemid, int userid)
        {
            dbmedia.AddReplytofile(text, mediaitemid, userid);

        }
        public void RemoveLikeToFile(int mediaitemid, int userid)
        {
            dbmedia.RemoveLikeToFile(mediaitemid, userid);

        }
        public void RemoveLikeToReply(int mediaitemid, int userid)
        {
            dbmedia.RemoveLikeToReply(mediaitemid, userid);

        }

        public List<Report> Getallreports()
        {
          return dbmedia.Getallreports();

        }

        public Report GetSingleReport(int mediaitemid, int userid)
        {
            return dbmedia.GetSingleReport(mediaitemid, userid);

        }

        public void RemoveReportedFile(int mediaitemid, int userid)
        {
            dbmedia.RemoveReportedFile(mediaitemid, userid);
        }

        public int GetMediaCategory(string categoryname)
        {
           return dbmedia.GetMediaCategory(categoryname);
        }


    }
}
