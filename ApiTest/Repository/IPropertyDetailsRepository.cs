using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Repository
{
    public interface IPropertyDetailsRepository
    {
        Task<List<Owner>> GetPropertyDetails();
        Task<Owner> GetDetailsById(int id);
    }
}
