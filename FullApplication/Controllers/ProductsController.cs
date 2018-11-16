using System;
using System.Collections.Generic;
using BusinessLayer.Abstractions;
using BusinessLayer.Implementations;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FullApplication.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IReadOnlyList<Products>> Get()
        {
            return Ok(_productRepository.GetAll<Products>());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Products> GetById(Guid id)
        {
            var product = _productRepository.GetById<Products>(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}