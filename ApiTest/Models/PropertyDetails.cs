using System.ComponentModel.DataAnnotations.Schema;



namespace ApiTest.Models
{
    public class PropertyDetails
    {
        public virtual Owner? Owner { get; set; }
        public virtual List<Property>? Property { get; set; }
    }
}
