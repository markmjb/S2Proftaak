using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer.Business
{
    public class Campspot
    {
        public int CampspotId { get; set; }
        public int Campplace { get; set; }
        public string Description { get; set; }
        public string Campingspottype { get; set; }
        public decimal Price { get; set; }

        public Campspot()
        {

        }

        public Campspot(int campspotId, int campplace, string description, string campingspottype, decimal price)
        {
            CampspotId = campspotId;
            Campplace = campplace;
            Description = description;
            Campingspottype = campingspottype;
            Price = price;
        }
    }
}
