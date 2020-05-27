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


          //The specification is only used for the product Entity that needs to retrun the type and brand too
        Task<T> GetTSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetTListSpec(ISpecification<T> spec);   
    }
}