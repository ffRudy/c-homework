using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace homework_12.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<Item> Items { get; set; }
    }
}