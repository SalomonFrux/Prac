using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.IImplemention
{
    public class ProductTypes : IProductTypes
    {
        private readonly StoreContext _context;

        public ProductTypes(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}