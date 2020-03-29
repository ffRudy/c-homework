using Microsoft.VisualStudio.TestTools.UnitTesting;
using home5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void InitTest()//初始化按订单总价排序
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            List<OrderItem> list1 = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            Order order2 = new Order("002", "Rudy", list1);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            OrderItem item4 = new OrderItem("苹果X", 5000, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order2.itemlist.Add(item3);
            order2.itemlist.Add(item4);
            orderlist.Add(order1);
            orderlist.Add(order2);
            OrderService service1 = new OrderService(orderlist);


            List<Order> orderlist1 = new List<Order>();
            orderlist1.Add(order2);
            orderlist1.Add(order1);
            OrderService service2 = new OrderService(orderlist1);
            service1.Init();//方法进行排序
            Assert.AreEqual(service2, service1);
        }

        [TestMethod()]
        public void ItemAddTest()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            OrderItem item4 = new OrderItem("苹果X", 5000, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);

            List<Order> orderlist1 = new List<Order>();
            Order torder1 = new Order("001", "付浩", list);
            OrderItem titem1 = new OrderItem("剃须刀", 488, 1);
            OrderItem titem2 = new OrderItem("小米9", 2288, 1);
            OrderItem titem3 = new OrderItem("Nike外套", 488, 1);
            OrderItem titem4 = new OrderItem("苹果X", 5000, 1);
            torder1.itemlist.Add(item1);
            torder1.itemlist.Add(item2);
            torder1.itemlist.Add(item3);
            torder1.itemlist.Add(item4);
            orderlist1.Add(order1);
            OrderService service2 = new OrderService(orderlist1);
            service2.ItemAdd(order1, "苹果X", 5000, 1);
            Assert.AreEqual(service2, service1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            OrderItem item4 = new OrderItem("苹果X", 5000, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            order1.itemlist.Add(item4);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);

            List<Order> orderlist1 = new List<Order>();
            Order torder1 = new Order("001", "付浩", list);
            OrderItem titem1 = new OrderItem("剃须刀", 488, 1);
            OrderItem titem2 = new OrderItem("小米9", 2288, 1);
            OrderItem titem3 = new OrderItem("Nike外套", 488, 1);
            torder1.itemlist.Add(item1);
            torder1.itemlist.Add(item2);
            torder1.itemlist.Add(item3);
            orderlist1.Add(order1);
            OrderService service2 = new OrderService(orderlist1);
            service2.Delete(order1, "苹果X");
            Assert.AreEqual(service2, service1);

        }

        [TestMethod()]
        public void ItemChangeTest()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);

            List<Order> orderlist1 = new List<Order>();
            Order torder1 = new Order("001", "付浩", list);
            OrderItem titem1 = new OrderItem("剃须刀", 488, 1);
            OrderItem titem2 = new OrderItem("小米9", 2288, 1);
            OrderItem titem3 = new OrderItem("Nike外套", 488, 2);
            torder1.itemlist.Add(item1);
            torder1.itemlist.Add(item2);
            torder1.itemlist.Add(item3);
            orderlist1.Add(torder1);
            OrderService service2 = new OrderService(orderlist1);
            service1.ItemChange(order1, "Nike外套",2);
            Assert.AreEqual(service2, service1);
        }

        [TestMethod()]
        public void SerchNameTest()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);      
            Assert.AreEqual(item2, service1.SerchName(order1, "小米9"));
        }

        [TestMethod()]
        public void SerchNameTest2()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);
            Assert.AreEqual(null, service1.SerchName(order1, "小米8"));
        }

        [TestMethod()]
        public void SerchPriceTest()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);
            List<OrderItem> tlist = new List<OrderItem>();
            tlist.Add(item1);
            tlist.Add(item3);
            CollectionAssert.Equals(tlist,service1.SerchPrice(order1, 488));
        }
        [TestMethod()]
        public void SerchPriceTest2()
        {
            List<Order> orderlist = new List<Order>();
            List<OrderItem> list = new List<OrderItem>();
            Order order1 = new Order("001", "付浩", list);
            OrderItem item1 = new OrderItem("剃须刀", 488, 1);
            OrderItem item2 = new OrderItem("小米9", 2288, 1);
            OrderItem item3 = new OrderItem("Nike外套", 488, 1);
            order1.itemlist.Add(item1);
            order1.itemlist.Add(item2);
            order1.itemlist.Add(item3);
            orderlist.Add(order1);
            OrderService service1 = new OrderService(orderlist);
            CollectionAssert.Equals(null, service1.SerchPrice(order1, 388));
        }
    }
}