using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiTest.Models.DTO
{
    public class OwnerDTO
    {
        public int IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public byte[]? Photo { get; set; }
        public string? Birthday { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
