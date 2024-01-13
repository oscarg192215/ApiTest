using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Models.DTO
{
    public class PropertyTraceDTO
    {
        [Key]
        public int IdPropertyTrace { get; set; }
        public int IdProperty { get; set; }
        public string? DateSale { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }
}
