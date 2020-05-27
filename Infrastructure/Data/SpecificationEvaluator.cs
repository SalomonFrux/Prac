using System;
using System.Globalization;
using System.Linq;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T :BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> queryableProduct, ISpecification<T> spec)
        {
            var Product = queryableProduct;

            //If we have and expression with condition
            if( spec.ConditionExp != null)
            {
                Product = Product.Where(spec.ConditionExp); //product.id == id passed in
            }
            //In case we want to return the Whole list, then spec == null: That means we only include
         Product = spec.IncludesExp.Aggregate(Product, (thisProduct, includesExp) => thisProduct.Include(includesExp));

         return Product; 
        }
    }
}