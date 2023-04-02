using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        TestContext _dbContext;
        public CustomerController(TestContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Customers.ToList());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Customers.Find(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if(customer != null)
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return Ok("Customer Created Successfully");
            }
            return BadRequest();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var result = _dbContext.Customers.Find(id);
            if(result != null)
            {
                result.CustomerName = customer.CustomerName;
                result.Gender = customer.Gender;

                _dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges(true);
                return Ok("Customer updated Successfully");
            }
            return BadRequest();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _dbContext.Customers.Find(id);
            if (result != null)
            {
                _dbContext.Customers.Remove(result);
                _dbContext.SaveChanges(true);
                return Ok($"Customer with ID {id} deleted Successfully");
            }
            return BadRequest();
        }
    }
}
