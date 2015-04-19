﻿using System;
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
        public void ChangePrice(string name, int price)
        {
            DM.ChangePrice(name, price);
        }
        public void AddStock(string naam, int aantal)
        {
            for(int i = 0; i < aantal; i++)
            {
                if(naam == "USBstick")
                {
                    DM.AddStock(naam, "Een 16GB USB stick", 35, 1, 1);
                }
                if (naam == "Ethernetkabel")
                {
                    DM.AddStock(naam, "Een internetkabel van 10meter", 20, 2, 1);
                }
                if (naam == "Laptop")
                {
                    DM.AddStock(naam, "Een gemiddelde laptop", 200, 3, 1);
                }
                if (naam == "Accu")
                {
                    DM.AddStock(naam, "Een goede accu voor de laptop", 15, 4, 1);
                }
            }
        }
        public int UpdateTotalPrice(string name)
        {
            int price =  DM.UpdateTotalPrice(name);
            return price;
        }
    }
}
