using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal Price { get; set; }
        public string? CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public List<PropertyImage> PropertyImage { get; set; }
        [ForeignKey(nameof(IdProperty))]
        public List<PropertyTrace> PropertyTrace { get; set; }
    }
}
