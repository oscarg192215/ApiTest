using ApiTest.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiTest.Repository
{
    public interface IPasswordHasherRepository
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string passwordToCheck);
    }
}
