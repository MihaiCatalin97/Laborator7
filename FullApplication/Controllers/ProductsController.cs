using System;
using System.Collections.Generic;
using BusinessLayer.Abstractions;
using BusinessLayer.Implementations;
using DataLayer.Entities;
using FullApplication.Models;
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
        public ActionResult<Products> Post([FromBody] ProductsModel productModel)
        {
            if (productModel == null)
            {
                return BadRequest();
            }
            
            Products products = new Products(productModel.Name, productModel.Price, productModel.Pieces);
            _productRepository.Create(products);
            _productRepository.Save();

            return CreatedAtRoute("Post", new {Id = products.Id}, products);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public ActionResult<ShoppingCart> Put(Guid id, [FromBody] ProductsModel productsModel)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var result = _productRepository.GetById<ShoppingCart>(id);

            if (result == null)
            {
                return NotFound();
            }

            var newProducts = new Products(productsModel.Name, productsModel.Price, productsModel.Pieces);

            _productRepository.Update<Products>(newProducts);
            _productRepository.Save();

            return Ok();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _productRepository.GetById<Products>(id);

            if (result == null)
            {
                return NotFound();
            }

            _productRepository.Delete<Products>(result);
            _productRepository.Save();

            return Ok();
        }

    }
}