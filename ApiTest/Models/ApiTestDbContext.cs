using Microsoft.EntityFrameworkCore;
using ApiTest.Models;
using ApiTest.Models.DTO;

namespace ApiTest.Models
{
    public class ApiTestDbContext : DbContext
    {
        public ApiTestDbContext(DbContextOptions<ApiTestDbContext> options) : base(options)
        {
        }
        public DbSet<Owner>? Owner { get; set; }
        public DbSet<Property>? Property { get; set; }
        public DbSet<PropertyImage>? PropertyImage { get; set; }
        public DbSet<PropertyTrace>? PropertyTrace { get; set; }
    }
}
