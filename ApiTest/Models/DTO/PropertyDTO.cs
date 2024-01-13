using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiTest.Models.DTO
{
    public class PropertyDTO
    {
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal Price { get; set; }
        public string? CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public PropertyImage PropertyImage { get; set; }
        public PropertyTrace PropertyTrace { get; set; }
    }
}
