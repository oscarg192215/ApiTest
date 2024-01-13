using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository
{
    public class PropertyTraceRepository:IPropertyTraceRepository
    {
        private readonly ApiTestDbContext _context;

        public PropertyTraceRepository(ApiTestDbContext context)
        {
            _context = context;
        }

        public async Task AddPropertyTrace(PropertyTrace propertyTrace)
        {
            try
            {
                _context.Add(propertyTrace);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePropertyTrace(PropertyTrace propertyTrace)
        {
            try
            {
                _context.Remove(propertyTrace);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PropertyTrace> GetPropertyTraceById(int id)
        {
            try
            {
                return await _context.PropertyTrace.FirstOrDefaultAsync(x => x.IdPropertyTrace == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PropertyTrace>> GetPropertyTraces()
        {
            try
            {
                return await _context.PropertyTrace.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePropertyTrace(PropertyTrace propertyTrace)
        {
            try
            {
                _context.Update(propertyTrace);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
