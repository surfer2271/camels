using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models
{
    public class OrderViewModel
    {
        public int OrderID  {get; set;}
        public int Freight { get; set; }
        public DateTime   OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
    }
}
