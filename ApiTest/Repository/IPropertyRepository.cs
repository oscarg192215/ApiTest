using ApiTest.Models;
using ApiTest.Models.DTO;

namespace ApiTest.Repository
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetProperties();
        Task<Property> GetPropertyById(int id);
        Task AddProperty(Property property);
        Task UpdateProperty(Property property);
        Task DeleteProperty(int id);
        Task<List<Property>> Search(FiltersDTO filters);
    }
}
