using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuNhanTamTinh.Models
{
    public class Food
    {
        public int Id { get; set; }

        [DisplayName("Name")]

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? FoodName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Manufacturer { get; set; }

        [Display(Name = "Release Date")]

        [DataType(DataType.Date), DisplayName("MFD")]
        public DateTime ManufacturingDate { get; set; }

        [DataType(DataType.Date), DisplayName("EXP")]
        public DateTime ExpiryDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
