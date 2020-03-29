using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace home5
{
    public class Order
    {
        public String orderNumber;
        public String buyerName;
        public List<OrderItem> itemlist;
        public int Orderprice
        {
            get 
            {
                int p = 0;
                foreach (OrderItem or in this.itemlist)
                {
                    p = p + (or.itemPrice * or.itemNum);
                }
                return p;
            }
            set{}
        }

        public int Getorderprice()
        {
            int p = 0;
            foreach (OrderItem or in this.itemlist)
            {
                p = p + (or.itemPrice * or.itemNum);
            }
            return p;
        }
        public void Setorderprice(int num)
        {
        }

        public String GetorderNumber()
        {
            return orderNumber;
        }
        public String GetbuyerName()
        {
            return buyerName;
        }
        public Order(String orderNumber, String buyerName, List<OrderItem> itemlist)
        {
            this.orderNumber = orderNumber;
            this.buyerName = buyerName;
            this.itemlist = itemlist;
        }
        public override bool Equals(Object other)
        {
            var toCompareWith = other as Order;
            if (toCompareWith == null)
                return false;

            if (this.itemlist.Count != toCompareWith.itemlist.Count)
                return false;
            for (int i = 0; i < this.itemlist.Count; i++)
            {
                if (!this.itemlist.ElementAt(i).Equals(toCompareWith.itemlist.ElementAt(i)))
                    return false;
            }
            return true;
        }
        public Order()
        {
        }
        public override string ToString()
        {
            return "订单 [订单编号=" + orderNumber + ", 用户名称=" + buyerName + ", 订单总价=" + this.Orderprice + "]";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class OrderItem
    {
        public String itemName;
        public int itemPrice;
        public int itemNum;
        public OrderItem() { }
        public OrderItem(String itemName, int itemPrice, int itemNum)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemNum = itemNum;
        }
        public String GetItemName()
        {
            return itemName;
        }
        public void SetItemnum(int x)
        {
            this.itemNum = x;
        }
        public int GetItemPrice()
        {
            return itemPrice;
        }
        public Boolean Equals(string name)
        {
            if (name == itemName)
            {
                return true;
            }
            return false;
        }
        public Boolean Equals(int price)
        {
            if (price == itemPrice)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(Object other)
        {
            var toCompareWith = other as OrderItem;
            if (toCompareWith == null)
                return false;
            return this.itemName == toCompareWith.itemName&&
                this.itemPrice == toCompareWith.itemPrice &&
                this.itemNum == toCompareWith.itemNum;
        }
        public override string ToString()
        {
            return "物品 [物品名称=" + itemName + ", 物品单价=" + itemPrice + ", 物品数量=" + itemNum + "]";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class OrderService
    {
        public List<Order> orderList;
        public Order neworder;
        public void Init()
        {
            orderList.Sort((Order h1, Order h2) =>                   //按订单总值进行降序排列
            {
                return h2.Orderprice.CompareTo(h1.Orderprice);
            });
        }
        public void Export()
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xmlserializer.Serialize(fs, this.orderList);
            }
            Console.WriteLine(File.ReadAllText("order.xml"));
        }
        public void Import()
        {
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
                List<Order> transorder = (List<Order>)xmlserializer.Deserialize(fs);
            }
        }
        public OrderService(List<Order> orderlist)
        {
            this.orderList = orderlist;
        }
        public void ItemAdd(Order order,string name, int price, int num)
        {
            OrderItem item = new OrderItem(name, price, num);
            order.itemlist.Add(item);
        }
        public void Delete(Order order, string itemname)
        {
            IEnumerable<OrderItem> query =
                from s in order.itemlist
                where s.Equals(itemname)
                select s;
            OrderItem orderitem = query.First();
            Console.WriteLine("删除成功：" + "【订单号"+order.orderNumber+"】"+ orderitem.itemName + " 价格: " + orderitem.itemPrice);
            Console.WriteLine();
            order.itemlist.Remove(orderitem);
            orderList.Sort((Order h1, Order h2) =>                   //按订单总值进行降序排列
            {
                return h2.Orderprice.CompareTo(h1.Orderprice);
            });
        }
        public void ItemChange(Order order, string name, int num)//修改物品的购买数量
        {
            IEnumerable<OrderItem> query =
                from s in order.itemlist
                where s.Equals(name)
                select s;
            OrderItem orderitem = query.First();
            orderitem.SetItemnum(num);
            Console.WriteLine("修改成功：" + "【订单号" + order.orderNumber + "】"+ orderitem.itemName + " 价格: " + orderitem.itemPrice + " 数量：" + orderitem.itemNum);
            Console.WriteLine();
            orderList.Sort((Order h1, Order h2) =>                   //按订单总值进行降序排列
            {
                return h2.Orderprice.CompareTo(h1.Orderprice);
            });
        }
        public OrderItem SerchName(Order order,string itemname)//根据名字查询物品
        {
            IEnumerable<OrderItem> query =
                from s in order.itemlist
                where s.Equals(itemname)
                select s;
            OrderItem orderitem = query.FirstOrDefault();
            if (orderitem == null) { Console.WriteLine("查询失败！");return null; }
            Console.WriteLine("查询成功：" + "【订单号" + order.orderNumber + "】" + orderitem.itemName + " 价格: " + orderitem.itemPrice + " 数量：" + orderitem.itemNum);
            return orderitem;
        }
        public List<OrderItem> SerchPrice(Order order, int price)//根据价格查询物品
        {
            List<OrderItem> list = new List<OrderItem>();
            IEnumerable<OrderItem> query =
                from s in order.itemlist
                where s.Equals(price)
                orderby s.itemNum * s.itemPrice
                select s;
            OrderItem orderitem = query.FirstOrDefault();
            if (orderitem == null) { Console.WriteLine("查询失败！"); }
            foreach(OrderItem or in query)
            {
                Console.WriteLine("查询成功：" + "【订单号" + order.orderNumber + "】" + or.itemName + " 价格: " + or.itemPrice + " 数量：" + or.itemNum);
                list.Add(or);
            }
            return list;
        }
        public override bool Equals(Object other)
        {
            var toCompareWith = other as OrderService;
            if (toCompareWith == null)
                return false;

            if (this.orderList.Count != toCompareWith.orderList.Count)
                return false;
            for (int i = 0; i < this.orderList.Count; i++)
            {
                if (!this.orderList.ElementAt(i).Equals(toCompareWith.orderList.ElementAt(i)))
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            string ot="";
            foreach (Order or in this.orderList)
            {
                ot = ot + "  订单 [订单编号=" + or.orderNumber + ", 用户名称=" + or.buyerName + ", 订单总价=" + or.Orderprice + "]" + "\n";
                foreach (OrderItem it in or.itemlist)
                {
                    ot = ot + "物品 [物品名称=" + it.itemName + ", 物品单价=" + it.itemPrice + ", 物品数量=" + it.itemNum + "]"+"\n";
                }
            }
            return ot;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            List<OrderItem> list1 = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            Order order2 = new Order("002", "Rudy", list1);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("牛奶", 288, 3);
            OrderItem item4 = new OrderItem("眼镜", 288, 1);
            OrderItem item5 = new OrderItem("派克钢笔", 288, 2);
            OrderItem item6 = new OrderItem("Nike外套", 488, 1);
            OrderItem item7 = new OrderItem("苹果X", 5000, 1);
            OrderItem item8 = new OrderItem("牛奶", 288, 2);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            order1.itemlist.Add(item4);
            order1.itemlist.Add(item5);
            order2.itemlist.Add(item6);
            order2.itemlist.Add(item7);
            order2.itemlist.Add(item8);
            orderlist.Add(order1);
            orderlist.Add(order2);
            OrderService service1 = new OrderService(orderlist);
            service1.Init();
            service1.ItemAdd(order1,"吹风机", 99, 1);
            Console.WriteLine(service1);
            service1.Delete(order1,"剃须刀");
            service1.ItemChange(order1,"小米9", 3);
            Console.WriteLine(service1);
            service1.SerchName(order1,"剃须刀");
            service1.SerchPrice(order2,1288);
            service1.Export();
            service1.Import();
        }
    }
}

