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
        DbAccess DA = new DbAccess();
        DbEvent DE = new DbEvent();
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
        public void GiveUserDebt(int userId, int eventId, int debt)
        {
            DM.GiveUserDept(userId, eventId, debt);
        }
        public void ReturnMaterial(int materialID, string materialName, string description, double price, int materialTypeID, int eventID)
        {
            DM.ReturnMaterial(materialID, materialName, description, price, materialTypeID, eventID);
        }
        public User RFIDuser(string RFID)
        {
            if (DA.GetRFIDStatus(RFID))
            {
                return DM.GetRFIDuser(RFID);
            }
            return null;
        }
        public List<Event> GetEvents()
        {
            List<Event> Events = DE.GetEvents();
            return Events;
        }
    }
}
