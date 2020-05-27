using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;

namespace Core.Interfaces
{
    public interface IGenericProductRepo<T> where T: BaseEntity
    {
         Task<T> GetEntityByIdAsync(int id);
         Task<IReadOnlyList<T>> GetEntitiesAsync();       

        Task<T> GetEntitiesSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetEntitiesListSpec(ISpecification<T> spec);   
    }
}