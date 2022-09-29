﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Books.Models;

namespace Books.Controllers
{
    public class AuthController : ApiController
    {
        private IAuthRepository repository;
        AuthController()
        {
            repository = new AuthSqlImpl();
        }
        [HttpPost]
        public IHttpActionResult Post(Auth auth)
        {
            var data = repository.RegisterUser(auth);
            return Ok(data);
        }

        [HttpGet]

        public IHttpActionResult Get(string id, string passwd)
        {
            var data = repository.ValidateUser(id, passwd);            
            return Ok(data);
        }



    }
}
