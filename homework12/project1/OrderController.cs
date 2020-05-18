using homework_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace homework_12.Controllers
{
    public class OrderController : ApiController
    {
        Order[] orders = new Order[]
        {
                new Order{OrderId = 1,Customer = "Fuhao",Items = new List<Item>(){
                    new Item() { Name = "phone",Num = 1},
                    new Item() { Name = "milk" ,Num = 4}
                   }
                 },
                new Order{OrderId = 2,Customer = "Rudy",Items = new List<Item>(){
                    new Item() { Name = "phone",Num = 1},
                    new Item() { Name = "milk" ,Num = 4}
                   }
            }
        };
        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        public IHttpActionResult GetOrder(int id)
        {
            var order = orders.FirstOrDefault((p) => p.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
