using ApiTest.Models;
using ApiTest.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApiTestDbContext _context;

        public PropertyRepository(ApiTestDbContext context)
        {
            _context = context;
        }

        public async Task AddProperty(Property property)
        {
            try
            {
                _context.Add(property);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProperty(int id)
        {
            try
            {
                var property = await _context.Property.Include(o => o.PropertyImage).Include(x=>x.PropertyTrace).FirstOrDefaultAsync(x => x.IdProperty == id);
                if (property != null)
                {
                    _context.Remove(property);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Property>> GetProperties()
        {
            try
            {
                return await _context.Property.Include(o => o.PropertyImage).Include(x=>x.PropertyTrace).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Property> GetPropertyById(int id)
        {
            try
            {
                return await _context.Property.Include(o => o.PropertyImage).Include(x => x.PropertyTrace).FirstOrDefaultAsync(x => x.IdProperty == id); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProperty(Property property)
        {
            try
            {
                _context.Update(property);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
