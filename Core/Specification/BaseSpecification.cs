using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseSpecification()
        {
            
        }

        public BaseSpecification(Expression<Func<T, bool>> conditionExp)
        {
            ConditionExp = conditionExp;
        }

        public Expression<Func<T, bool>> ConditionExp{get;} 

        public List<Expression<Func<T, object>>> IncludesExp {get; } = new List<Expression<Func<T, object>>>();

       protected void Addinclude(Expression<Func<T, object>> NewInclude)
        {
            IncludesExp.Add(NewInclude);  // x=> x.ProductBrand ...
        }
    }
}