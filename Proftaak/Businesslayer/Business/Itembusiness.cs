using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslayer.DAL;

namespace Businesslayer.Business
{
    public class Itembusiness
    {
        DbMaterial DM = new DbMaterial();
        public List<Item> GetItems()
        {
            List<Item> items = DM.GetItems();
            return items;
        }
        public void ChangePrice(string name, decimal price)
        {
            DM.ChangePrice(name, price);
        }
    }
}
