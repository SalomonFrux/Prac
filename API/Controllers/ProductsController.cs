using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }


        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProductsList()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products); 
        }
    }
}