using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    public class Order
    { 
        
        public int OrderId { get; set; }

        public string Customer { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }
        public int Num { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
