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

        public int  GetAllLikes(int mediaitemid)
        {
            return dbmedia.GetAllLikes(mediaitemid);

        }

        public void AddLikeToFile(int mediaitemid,int userid)
        {
            dbmedia.AddLikeToFile(mediaitemid, userid);

        }
        public void AddLikeToReply(int mediaitemid,int userid)
        {
            dbmedia.AddLikeToReply(mediaitemid, userid);

        }
        public void RemoveLikeToFile(int mediaitemid, int userid)
        {
            dbmedia.RemoveLikeToFile(mediaitemid, userid);

        }
        public void RemoveLikeToReply(int mediaitemid, int userid)
        {
            dbmedia.RemoveLikeToReply(mediaitemid, userid);

        }
    }
}
