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
        private readonly IGenericProductRepo<Products> _genericProducts;
        private readonly IGenericProductRepo<ProductType> _genericType;
        private readonly IGenericProductRepo<ProductBrand> _genericBrand;
        public ProductsController(IGenericProductRepo<Products> genericProducts, IGenericProductRepo<ProductType> genericType, IGenericProductRepo<ProductBrand> genericBrand)
        {
            _genericProducts = genericProducts;
            _genericType = genericType;
            _genericBrand = genericBrand;
        }
          

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var newspec = new ProductsWithBrandAndTypeSpec(id);
            return await _genericProducts.GetEntitiesSpec(newspec);
        }


        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProductsList()
        {
             var newspec = new ProductsWithBrandAndTypeSpec();
            var products = await _genericProducts.GetEntitiesListSpec(newspec); //Create the specification class now
            return Ok(products);
        }

        [HttpGet ("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrandtsList()
        {
            var productsBrand = await _genericBrand.GetEntitiesAsync();
            return Ok(productsBrand);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypesList()
        {
            var productsType = await _genericType.GetEntitiesAsync();
            return Ok(productsType);
        }
    }
}