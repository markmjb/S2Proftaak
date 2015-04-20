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
        DbMaterial DM = new DbMaterial();
        public List<Item> Items { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

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
    }
}