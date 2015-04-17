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

        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public void ChangePrice(string name, decimal price)
        {
            DM.ChangePrice(name, price);
        }

    }
}