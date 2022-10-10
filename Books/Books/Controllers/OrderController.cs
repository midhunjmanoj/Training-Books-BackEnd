using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Books.Models;

namespace Books.Controllers
{
    [EnableCors(origins: "http://localhost:4200/book", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        private IOrderRepository repository;
        public OrderController()
        {
            repository = new OrderSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(string uid)
        {
            var data = repository.GetOrderByUserId(uid); ;
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetOrder(string orderid)
        {
            var data = repository.ViewOrder(orderid);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            var data = repository.MakeOrder(order);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(string oid)
        {
            repository.DeleteOrder(oid);
            return Ok();
        }
    }
}
