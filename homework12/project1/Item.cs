using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace homework_12.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Num { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}