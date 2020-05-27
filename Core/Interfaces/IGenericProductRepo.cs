using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericProductRepo<T> where T: BaseEntity
    {
         Task<T> GetEntityByIdAsync(int id);
         Task<IReadOnlyList<T>> GetEntitiesAsync();         
    }
}