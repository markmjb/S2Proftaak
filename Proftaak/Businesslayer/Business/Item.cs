using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public Item(string name, int price, int id)
        {
            Name = name;
            ID = id;
            Price = price;
        }

        public Item(string name, int price, DateTime startdate, DateTime enddate)
        {
            Name = name;
            Price = price;
            StartDate = startdate;
            EndDate = enddate;
        }

        public Item()
        {
        }
    }
}