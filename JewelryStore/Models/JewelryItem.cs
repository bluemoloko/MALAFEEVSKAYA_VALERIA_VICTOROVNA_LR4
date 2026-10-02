using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class JewelryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MetalType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
