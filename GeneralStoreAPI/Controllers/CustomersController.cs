using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{ 
    public class CustomersController : ApiController
    {
        private readonly GeneralStoreDbContext _context = new GeneralStoreDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateCustomer([FromBody] Customer model)
        {
            if (model is null)
                return BadRequest("Body not provided");
            if(ModelState.IsValid)
            {
                _context.Customers.Add(model);
                if (ModelState.IsValid)
                {
                    _context.Customers.Add(model);
                    await _context.SaveChangesAsync();
                    return Ok("New Customer created.");
                }
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerById([FromUri]int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCustomer([FromUri] int id, [FromBody] Customer updatedCustomer)
        {
            if (id != updateCustomer?.Id)
                return BadRequest("IDs don't match.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Customer customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return NotFound();
            if (updatedCustomer.FirstName != null)
                customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
        }
    }
}