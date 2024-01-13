using ApiTest.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace ApiTest.Repository
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly ApiTestDbContext _context;

        public PropertyImageRepository(ApiTestDbContext context)
        {
            _context = context;
        }

        public async Task AddPropertyImage(PropertyImage propertyImage)
        {
            try
            {
                _context.Add(propertyImage);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePropertyImage(PropertyImage propertyImage)
        {
            try
            {
                _context.Remove(propertyImage);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PropertyImage> GetPropertyImageById(int id)
        {
            try
            {
                return await _context.PropertyImage.FirstOrDefaultAsync(x=>x.IdPropertyImage == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PropertyImage>> GetPropertyImages()
        {
            try
            {
                return await _context.PropertyImage.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePropertyImage(PropertyImage propertyImage)
        {
            _context.Update(propertyImage);
            await _context.SaveChangesAsync();
        }
    }
}
