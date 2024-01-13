using ApiTest.Models;
using ApiTest.Models.DTO;

namespace ApiTest.Repository
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetOwners();
        Task<Owner> GetOwnerById(int id);
        Task<Owner> GetOwnerByEmail(string email, string pass);
        Task AddOwner(Owner owner);
        Task UpdateOwner(Owner owner);
        Task DeleteOwner(int id);
    }
}
