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
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public void ChangePrice(string name, double price)
        {
            DM.ChangePrice(name, price);
        }

    }
}