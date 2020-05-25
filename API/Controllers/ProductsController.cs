using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController
    {
        private readonly IProductRepository<Products> _repo;

        public ProductsController(IProductRepository<Products> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public void GetProduct(int id)
        {
            _repo.GetProductByIdAsync(id);
        }

          [HttpGet]
        public void GetProducts()
        {
           _repo.GetProductsAsync();
        }
    }
}