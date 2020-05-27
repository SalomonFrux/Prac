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
    }
}