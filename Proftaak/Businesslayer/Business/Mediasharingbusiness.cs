using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class Mediasharingbusiness
    {
        DbMedia dbmedia = new DbMedia();
        public int getcategory(string category)
        {
            return dbmedia.GetCategoryID(category);
        }

        public int GetmediaitemID(string Title)
        {
            return dbmedia.GetMediaItemID(Title);
        }

    }
}
