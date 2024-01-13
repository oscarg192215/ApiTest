using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class PropertyImage
    {
        [Key]
        public int IdPropertyImage { get; set; }
        [JsonIgnore]
        public int IdProperty { get; set; }
        public byte[]? Files { get; set; }
        public bool Enabled { get; set; }
    }
}
