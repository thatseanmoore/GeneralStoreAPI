using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralStoreAPI.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly GeneralStoreDbContext _context = new GeneralStoreDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateProduct([FromBody] Product model)
        {
            if (model is null)
                return BadRequest("Cannot be blank");
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                await _context.SaveChangesAsync();
                return Ok("Product saved!");
            }
            return BadRequest(ModelState);
        }
    }
}