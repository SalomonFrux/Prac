using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Core.Entities;

namespace Core.Specification
{
    public interface ISpecification<T> where T : BaseEntity
    {
      Expression<Func<T, bool>> ConditionExp {get;}
      List<Expression<Func<T, object>>> IncludesExp {get;}
    }
}