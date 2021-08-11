using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;

namespace Northwind.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public  DateTime OrDateTime { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }

    }
}
