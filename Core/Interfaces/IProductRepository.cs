using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
          Task<IReadOnlyList<Products>> GetProductsAsync();
          Task<Products> GetProductByIdAsync(int id);
    }
}