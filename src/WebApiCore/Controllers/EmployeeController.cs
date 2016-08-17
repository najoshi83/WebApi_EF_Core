using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Interface;
using WebApiCore.Repository;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class EmployeeController : Controller
    {
        private Repository.EmployeeRepository __repository = new Repository.EmployeeRepository();
        // GET: api/values
        
        [HttpGet]
        public IEnumerable<Models.Employee> Get()
        {
          return new Repository.EmployeeRepository().GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Models.Employee obj)
        {
           
            __repository.Create(obj);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Models.Employee obj)
        {
            __repository.Update(obj);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            __repository.Delete(id);
        }
    }
}
