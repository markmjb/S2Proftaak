using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace Businesslayer
{
    public class Mediasharingbusiness
    {
        DbMedia dbmedia = new DbMedia();
        public int getcategory(string category)
        {
            return dbmedia.GetCategoryID(category);
        }
    }
}
