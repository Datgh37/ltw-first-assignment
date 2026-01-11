using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuNhanTamTinh.Models
{
    public class Food
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string? FoodName { get; set; }
        public string? Manufacturer { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date), DisplayName("MFD")]
        public DateTime ManufacturingDate { get; set; }

        [DataType(DataType.Date), DisplayName("EXP")]
        public DateTime ExpiryDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
