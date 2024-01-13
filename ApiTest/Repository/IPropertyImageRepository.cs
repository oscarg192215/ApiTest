using ApiTest.Models;

namespace ApiTest.Repository
{
    public interface IPropertyImageRepository
    {
        Task<List<PropertyImage>> GetPropertyImages();
        Task<PropertyImage> GetPropertyImageById(int id);
        Task AddPropertyImage(PropertyImage propertyImage);
        Task UpdatePropertyImage(PropertyImage propertyImage);
        Task DeletePropertyImage(PropertyImage propertyImage);
    }
}
