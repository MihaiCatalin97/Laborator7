using BusinessLayer.Implementations;
using DataLayer.Entities;
using FullApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FullApplication.Controllers
{
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartRepository _shopppingCartRepository;

        public ShoppingCartController(ShoppingCartRepository shopppingCartRepository)
        {
            _shopppingCartRepository = shopppingCartRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<ICollection<ShoppingCart>> GetAll()
        {
            return Ok (_shopppingCartRepository.GetAll<ShoppingCart>());           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ShoppingCart> GetById(Guid id)
        { 
            var result = _shopppingCartRepository.GetById<ShoppingCart>(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ShoppingCart> Post([FromBody] ShoppingCartModel shoppingCart)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var newShoppingCart = new ShoppingCart(shoppingCart.Date, shoppingCart.Description);

            return CreatedAtAction(nameof(GetById), new { id = newShoppingCart.Id }, newShoppingCart);
        }

              
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<ShoppingCart> Put(Guid id, [FromBody] ShoppingCartModel shoppingCart)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var result = _shopppingCartRepository.GetById<ShoppingCart>(id);

            if (result == null)
            {
                return NotFound();
            }

            var newShoppingCart = new ShoppingCart(shoppingCart.Date, shoppingCart.Description);

            _shopppingCartRepository.Update<ShoppingCart>(newShoppingCart);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _shopppingCartRepository.GetById<ShoppingCart>(id);

            if (result == null)
            {
                return NotFound();
            }

            _shopppingCartRepository.Delete<ShoppingCart>(result);

            return Ok();
        }
    }
}
