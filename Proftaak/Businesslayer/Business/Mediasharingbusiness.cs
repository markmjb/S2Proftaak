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
        public Mediaitem Getsinglemediaitem(int mediaitemid)
        {
            return dbmedia.Getsinglemediaitem(mediaitemid);
            
        }

        public Mediaitem Getsinglemediaitemfile(int mediaitemid)
        {
            return dbmedia.Getsinglemediaitemfile(mediaitemid);

        }

    }
}
