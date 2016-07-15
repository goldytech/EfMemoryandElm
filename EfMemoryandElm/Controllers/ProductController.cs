using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EfMemoryandElm.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
       private readonly ILogger<ProductController> logger;
       private readonly InMemoryDbContext dbContext;
       public ProductController (ILogger<ProductController> logger, InMemoryDbContext dbContext){
            this.logger = logger;
            this.dbContext = dbContext;

       }
       
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var productsList = await this.dbContext.Products.ToListAsync();
           return Ok(productsList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           var producttobeFound = await this.dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
           if (producttobeFound == null){
               this.logger.LogInformation(2, "No product found");
               return NotFound();

           }
           return Ok(producttobeFound);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
            this.logger.LogInformation(1,"New product created");
            return Created("Get",product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
