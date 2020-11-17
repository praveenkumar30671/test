using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase;
using Microsoft.AspNetCore.Mvc;
using realone.Interface;
using realone.model;
using realone.service;
using Microsoft.AspNetCore.Cors;

namespace realone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class LoginController : ControllerBase

    {
        private readonly ILoginService _Iservice;

        public LoginController(ILoginService Iservice)
        {
            _Iservice = Iservice;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public async Task<List<Logindetails>> Get()
        {

            var couchClient = await _Iservice.initialize();
            var loginDetails = await _Iservice.GetLoginDetails(couchClient);
            return loginDetails;

        }

       
    }
}
