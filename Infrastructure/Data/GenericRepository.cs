using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
           _context = context;
            
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.set<T>().FindAysnc(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.set<T>().ToListAsync();
        }
    }
}