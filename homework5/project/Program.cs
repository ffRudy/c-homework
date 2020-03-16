using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home5
{
    public class Order
    {
        public String orderNumber;
        public String buyerName;
        public List<OrderItem> list;
        public String GetorderNumber()
        {
            return orderNumber;
        }
        public String GetbuyerName()
        {
            return buyerName;
        }
        public Order(String orderNumber,String buyerName, List<OrderItem> list)
        {
            this.orderNumber = orderNumber;
            this.buyerName = buyerName;
            this.list = list;
        }
        public Order()
        {
        }
        public override String ToString()
        { 
            return "订单 [订单编号=" + orderNumber + ", 用户名称=" + buyerName+ "]";
        }
    }
    public class OrderItem
    {
        public String itemName;
        public int itemPrice;
        public int itemNum;
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
            if(name==itemName)
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
        public override string ToString()
        {
            return "物品 [物品名称=" + itemName + ", 物品单价=" + itemPrice + ", 物品数量=" + itemNum+"]";
        }
    }
    public class OrderService
    {
        public Order neworder;
        public OrderService(Order neworder)
        {
            this.neworder = neworder;
        }
        public void ItemAdd(string name,int price,int num)
        {
            OrderItem item = new OrderItem(name, price,num);
            neworder.list.Add(item);
        }
        public void Delete(string itemname)
        {
            IEnumerable<OrderItem> query =
                from s in neworder.list
                where s.Equals(itemname)
                select s;
            OrderItem orderitem = query.First();
            Console.WriteLine("删除成功：" + orderitem.itemName + " 价格: " + orderitem.itemPrice);
            Console.WriteLine();
            neworder.list.Remove(orderitem);
        }
        public void ItemChange(string name,int num)//修改物品的购买数量
        {
            IEnumerable<OrderItem> query =
                from s in neworder.list
                where s.Equals(name)
                select s;
            OrderItem orderitem = query.First();
            orderitem.SetItemnum(num);
            Console.WriteLine("修改成功：" + orderitem.itemName + " 价格: " + orderitem.itemPrice + " 数量：" + orderitem.itemNum);
            Console.WriteLine();
        }
        public void SerchName(string itemname)//根据名字查询物品
        {
            IEnumerable<OrderItem> query =
                from s in neworder.list
                where s.Equals(itemname)
                orderby s.itemNum* s.itemPrice
                select s;
            foreach (OrderItem or in query)
                Console.WriteLine("查询成功：" + or.itemName + " 价格: " + or.itemPrice + " 数量：" + or.itemNum);
            Console.WriteLine();
        }
        public void SerchPrice(int price)//根据价格查询物品
        {
            IEnumerable<OrderItem> query =
                from s in neworder.list
                where s.Equals(price)
                orderby s.itemNum*s.itemPrice
                select s;
            foreach (OrderItem or in query)
                Console.WriteLine("查询成功：" + or.itemName + " 价格: " + or.itemPrice + " 数量：" + or.itemNum);
            Console.WriteLine();
        }
        public void Show()
        {
            Console.WriteLine("订单号为" + neworder.orderNumber + "的客户" + neworder.buyerName + "订单如下:");
            foreach (OrderItem or in neworder.list)
                Console.WriteLine("物品名：" + or.itemName + " 价格: " + or.itemPrice + " 数量：" + or.itemNum);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩",list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("牛奶", 288, 3);
            OrderItem item4 = new OrderItem("眼镜", 288, 1);
            OrderItem item5 = new OrderItem("派克钢笔", 288, 2);
            order1.list.Add(item1);
            order1.list.Add(item2);
            order1.list.Add(item3);
            order1.list.Add(item4);
            order1.list.Add(item5);
            OrderService service1 = new OrderService(order1);
            service1.ItemAdd("吹风机", 99, 1);
            Console.WriteLine(order1.ToString());
            foreach (OrderItem or in order1.list)
                Console.WriteLine(or.ToString());
            Console.WriteLine();
            service1.Delete("剃须刀");
            service1.ItemChange("小米9", 3);
            Console.WriteLine(order1.ToString());
            foreach (OrderItem or in order1.list)
                Console.WriteLine(or.ToString());
            Console.WriteLine();
            service1.SerchName("剃须刀");
            service1.SerchPrice(288);
        }    
    }
}
