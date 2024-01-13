using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public byte[] ?Photo { get; set; }
        public string? Birthday { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        [ForeignKey(nameof(IdOwner))]
        public List<Property> Properties{ get; set; }
    }
}
