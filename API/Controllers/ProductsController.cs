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
        private readonly IProductBrands _brandsRepo;
        private readonly IProductTypes _typesRepo;

        public ProductsController
        ( IProductRepository repo, IProductBrands brandRepo, IProductTypes types)
        {
            _repo = repo;
            _brandsRepo = brandRepo;
            _typesRepo = types;
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

        [HttpGet ("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrandtsList()
        {
            var productsBrand = await _brandsRepo.GetProductBrandsAsync();
            return Ok(productsBrand);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypesList()
        {
            var productsType = await _typesRepo.GetProductTypesAsync();
            return Ok(productsType);
        }
    }
}