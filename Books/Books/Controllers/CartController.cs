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
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CartController : ApiController
    {
        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get(string userid)
        {
            var data = repository.GetUserCart(userid);
            return Ok(data);
        }


        [HttpPost]
        public IHttpActionResult Post( string userid,string bookid)
        {
            repository.AddBookToCart(userid,bookid);
            return Ok();
        }
        [HttpDelete]
        public void Delete(string userid,string bookid)
        {
            repository.DeleteBookFromCart(userid,bookid);
            return;
        }

        
    }
}
