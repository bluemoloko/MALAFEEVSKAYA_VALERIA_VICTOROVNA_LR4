using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryStore.Models;

namespace JewelryStore.Services
{
    public interface IJewelryServices
    {
        void AddItem(JewelryItem item);
        void SellItem(int id, int quantity);
        JewelryItem? GetItemById(int id);
        public List<JewelryItem> GetAllItems();
    }
}
