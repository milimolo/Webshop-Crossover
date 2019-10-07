using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.ApplicationService;
using WebShop.Core.Entity;

namespace CrossoverProject.WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeService _shoeService;
        public ShoesController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        // GET api/shoes
        [HttpGet]
        public ActionResult<IEnumerable<Shoe>> Get()
        {
            return _shoeService.GetAllShoes();
        }

        // GET api/Shoes/5---read by id 
        [HttpGet("{id}")]
        public ActionResult<Shoe> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");
            
            var coreShoe = _shoeService.FindShoesById(id);
            return new Shoe()
            {
                id = coreShoe .id,
                price= coreShoe .price,
                name= coreShoe .name ,
                description= coreShoe .description,
                size= coreShoe .size,
                brand=coreShoe . brand ,
                color=coreShoe .color ,
                type=coreShoe .type ,
                date =coreShoe .date
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}