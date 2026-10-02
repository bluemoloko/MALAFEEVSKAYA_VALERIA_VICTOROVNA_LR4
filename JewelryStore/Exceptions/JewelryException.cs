using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Exceptions
{
    public class JewelryException : Exception
    {
        public JewelryException(string mes) : base(mes) { }
    }
}
