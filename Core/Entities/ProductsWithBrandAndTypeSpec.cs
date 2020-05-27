using System;
using System.Linq.Expressions;
using Core.Specification;

namespace Core.Entities
{
    public class ProductsWithBrandAndTypeSpec : BaseSpecification<Products>
    {
        public ProductsWithBrandAndTypeSpec()
        {
           Addinclude( x=> x.ProductBrand);
           Addinclude( x=> x.ProductType);
        }

        public ProductsWithBrandAndTypeSpec(int id) 
        : base(x=> x.Id == id)
        {
        }
    }
}