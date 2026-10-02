using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryStore.Exceptions;
using JewelryStore.Models;

namespace JewelryStore.Services
{
    public class JewelryServices: IJewelryServices
    {
        private readonly List<JewelryItem> _items = new List<JewelryItem>();

        public void AddItem(JewelryItem item)
        {
            if (item == null)
                throw new JewelryException("Данные о ювелирном изделии не могут быть пустыми");
            if (item.Price <= 0)
                throw new JewelryException($"Недопустимая цена: {item.Price}");
            if (item.Quantity < 0)
                throw new JewelryException("Количество товара на складе не может быть отрицательным");

            _items.Add(item);
        }
        public void SellItem(int id, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                throw new JewelryException($"Изделие с ID {id} не найдено");
            if (quantity <= 0)
                throw new JewelryException("Количество для продажи должно быть больше нуля");
            if (item.Quantity < quantity)
                throw new JewelryException($"Недостаточно товара на складе");

            item.Quantity -= quantity;
        }

        public JewelryItem? GetItemById(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<JewelryItem> GetAllItems()
        {
            return _items.ToList();
        }
    }
}
