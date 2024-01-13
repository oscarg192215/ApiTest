using ApiTest.Models;

namespace ApiTest.Repository
{
    public interface IPropertyTraceRepository
    {
        Task<List<PropertyTrace>> GetPropertyTraces();
        Task<PropertyTrace> GetPropertyTraceById(int id);
        Task AddPropertyTrace(PropertyTrace propertyTrace);
        Task UpdatePropertyTrace(PropertyTrace propertyTrace);
        Task DeletePropertyTrace(PropertyTrace propertyTrace);
    }
}
