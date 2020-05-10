using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext() : base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderDBContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        private OrderDBContext db = new OrderDBContext();
        public string CreateOrder(int Id, string Name)//加
        {
            //将要添加的数据，封装成对象
            Order order = new Order { Customer = Name, OrderId = Id };
            db.Orders.Add(order);
            //当调用SaveChanges()时，EF会遍历所有的代理类对象，并根据标志生成相应的sql语句
            db.SaveChanges();
            return "添加成功！";
        }
        public string GetOrder()//读
        {
            var list = db.Orders.ToList();
            //将对象转为Json
            //需要添加NewtonSoft.Json程序包
            return JsonConvert.SerializeObject(list);
        }
        public string GetOrders(int id)//查
        {
            var list = db.Orders.Find(id);
            return JsonConvert.SerializeObject(list);
        }
        public string DeleteOrderById(int id)//删除
        {
            Order order = new Order { OrderId = id };
            //标记为删除状态
            db.Entry(order).State = EntityState.Deleted;
            db.SaveChanges();
            return "删除成功！";
        }
    }
}
