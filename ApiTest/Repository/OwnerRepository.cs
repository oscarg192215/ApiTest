using ApiTest.Models;
using ApiTest.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ApiTest.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private ApiTestDbContext _context;
        private readonly IPasswordHasherRepository _passwordHasher;

        public OwnerRepository(ApiTestDbContext context, IPasswordHasherRepository passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<Owner>> GetOwners()
        {
            try
            {
                return await _context.Owner.OrderBy(x => x.IdOwner).ToListAsync(); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            try
            {
                return await _context.Owner.FindAsync(id); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddOwner(Owner owner)
        {
            try
            {
                var passEncrypt = _passwordHasher.HashPassword(owner.Password);
                owner.Password = passEncrypt;
                _context.Add(owner);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateOwner(Owner owner)
        {
            try
            {
                var ownerActual = await _context.Owner.FindAsync(owner.IdOwner);

                if (ownerActual != null)
                {
                    if (owner.Password != null)
                    {
                        var passEncrypt = _passwordHasher.HashPassword(owner.Password);
                        owner.Password = passEncrypt;
                    }
                    else
                        owner.Password = ownerActual.Password;

                    ownerActual.IdOwner = owner.IdOwner;
                    ownerActual.Name = owner.Name;
                    ownerActual.Address = owner.Address;
                    ownerActual.Photo = owner.Photo;
                    ownerActual.Birthday = owner.Birthday;
                    ownerActual.Email = owner.Email;
                    ownerActual.Password = owner.Password;
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteOwner(int id)
        {
            try
            {
                var owner = await _context.Owner.FirstOrDefaultAsync(x => x.IdOwner == id);
                if (owner != null)
                {
                    _context.Remove(owner);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Owner> GetOwnerByEmail(string email, string pass)
        {
            var result = false;
            var owner = await _context.Owner.FirstOrDefaultAsync(x => x.Email == email);
            if (owner != null)
                result = _passwordHasher.VerifyPassword(owner?.Password, pass);
            return owner;
        }
    }
}
