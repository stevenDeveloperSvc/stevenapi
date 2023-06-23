using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        public productServices _productServices;
        public SalesController(productServices productServices)
        {
            _productServices = productServices;
        }

        // // GET: api/Product
        [HttpGet]
        public  async Task<IEnumerable<Product>> GetProduct()=>await _productServices.getAllProducts();


        
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProducts(int id)
        {
            var products = await _productServices.getProduct(id);

            return products is null ? NotFound() : products;
        }





    //    POST: api/Product
    //     To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product?>> PostProducts(Product products)
        {
           await _productServices.postProduct(products);

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }








        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  async Task< IActionResult > PutProducts(int id, Product products)
        {

            var idProduct =  await  _productServices.getById(id);
            if(idProduct is not null) {
                _productServices.putProduct(id,products);
                return Ok();
            }else{
                return NotFound();
            }
        

        }


 

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var products = await _productServices.getById(id);
            if (products is null)
            {
                return NotFound();
            }

           await  _productServices.deleteProducts(products);

            return Ok();

        }

      
    }
}
