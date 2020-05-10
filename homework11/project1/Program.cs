using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class Program
    {
        static void Main(string[] args)
        {

            OrderDBContext dbcontext = new OrderDBContext();
            if (dbcontext.Database.CreateIfNotExists())
            {
                Console.WriteLine("数据库已创建成功！");
                Console.Read();
            }
            else
            {
                Console.WriteLine("数据库已经存在，无需创建！");
            }
            Order order = new Order();
            {
                order.OrderId = 1;
                order.Customer = "Fuhao";
            };
            order.Items = new List<Item>()
                {
                    new Item(){Name="phone",Num=1},
                    new Item(){Name="milk" ,Num=4},
                };
            dbcontext.Orders.Add(order);
            dbcontext.SaveChanges();
            dbcontext.CreateOrder(2, "Rudy");
        }
    }
    
}
