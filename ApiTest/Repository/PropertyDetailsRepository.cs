using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository
{
    public class PropertyDetailsRepository : IPropertyDetailsRepository
    {
        private readonly ApiTestDbContext _context;

        public PropertyDetailsRepository(ApiTestDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> GetDetailsById(int id)
        {
            return await _context.Owner.Include(x => x.Properties).ThenInclude(x => x.PropertyImage).Include(x => x.Properties).ThenInclude(x => x.PropertyTrace).FirstOrDefaultAsync(x=>x.IdOwner == id);             
        }

        public async Task<List<Owner>> GetPropertyDetails()
        {
            return await _context.Owner.Include(x=>x.Properties).ThenInclude(x=>x.PropertyImage).Include(x=>x.Properties).ThenInclude(x=>x.PropertyTrace).ToListAsync();
            
        }
    }
}
