using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
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
            return await _context.Set<T>().ToListAsync();
        }
        public Task<T> GetEntityByIdAsync(int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }


                public async Task<IReadOnlyList<T>> GetTListSpec(ISpecification<T> spec)
        {
          return await ApplySpecification(spec).ToListAsync();
           
        }

        public Task<T> GetTSpec(ISpecification<T> spec)
        {
           return ApplySpecification(spec).FirstOrDefaultAsync();
        }


        private  IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
         return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }





        

    }
}