﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.ApplicationService;
using WebShop.Core.DomainService.Filtering;
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
        public ActionResult<FilteringList<Shoe>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_shoeService.GetFilteredShoes(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
  
            
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
        public ActionResult<Shoe>  Post([FromBody] Shoe shoe)
        {
            
                if (string.IsNullOrEmpty(shoe.name))
                {
                    return BadRequest("Name is Required for Creating a shoe");
                }

                if (string.IsNullOrEmpty(shoe.price.ToString( )))
                {
                    return BadRequest("Price is Required for Creating a shoe");
                }
            return _shoeService.CreateShoe(shoe);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Shoe> Put(int id, [FromBody] Shoe shoe)
        {
            
                if (id < 1 || id != shoe.id)
                {
                    return BadRequest("Parameter Id and shoe id must be the same");
                }

                return Ok(_shoeService .UpdateShoe( shoe ));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public  ActionResult<Shoe > Delete(int id)

        {
            var shoe = _shoeService.DeleteShoe(id);
                if (shoe == null)
                {
                    return StatusCode(404, "Did not find shoe with id " + id);
                }

                return Ok($"Shoe with ID: {id} has been deleted");
            }
        }
    }
