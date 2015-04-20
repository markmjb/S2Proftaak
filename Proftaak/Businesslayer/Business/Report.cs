using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer.Business
{
    public class Report
    {
        public int ReportedID { get; set; }
        public int MediaitemID { get; set; }
        public int UserID { get; set; }


         public Report(int reportedID, int mediaitemid, int UserID)
        {
            this.ReportedID = reportedID;
            this.MediaitemID = mediaitemid;
            this.UserID = UserID;
             

        }

        public Report()
        {
            
        }
    }
}
