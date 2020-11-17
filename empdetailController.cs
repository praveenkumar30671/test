using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using realone.Interface;
using realone.service;
using Couchbase;
using realone.model;
using Microsoft.AspNetCore.Cors;


namespace realone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class empdetailController : ControllerBase
    {
        private readonly IempdetailService _service;  
        public empdetailController(IempdetailService service)
        {
            _service = service;
        }

        // GET: api/<employeedetails>
        [HttpGet]
        public async Task<List<empdetails>> Get()
        {
            var couchClient = await _service.Initialize();
            var employees = await _service.GetEmployees(couchClient);
            return employees;
        }


        // GET api/<employeedetails>/5
        [HttpGet("{id}")]
        public async Task<empdetails> Get(int id)
        {
            var couchClient = await _service.Initialize();
            var employees = await _service.GetEmployeeBYid(couchClient, id);
            return employees;
        }

        //update
        // PUT api/<employeedetails>/5
        [HttpPut("{id}")]
        public async Task <empdetails> Put(int id,[FromBody] empdetails value)
        {
            var couchClient = await _service.Initialize();
            await _service.PutEmployeeBYid(couchClient, id, value);
            return null;

        }

        
        // DELETE api/<employeedetails>/5
        [HttpDelete("{id}")]
        public async Task<empdetails> Delete(int id)
        {
            var couchClient = await _service.Initialize();
            await _service.DeleteEmployees(couchClient, id);
            return null;
        }
    }
}
