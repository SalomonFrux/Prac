using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.IImplemention
{
    public class GenericProductRepo<T> : IGenericProductRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericProductRepo(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetEntitiesAsync()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetEntityByIdAsync(int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}