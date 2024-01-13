using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiTest.Models.DTO
{
    public class PropertyImageDTO
    {
        [Key]
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[]? Files { get; set; }
        public bool Enabled { get; set; }
    }
}
