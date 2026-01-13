using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuNhanTamTinhRazorPage.Models
{
    public class Food
    {
        public int Id { get; set; }

        [DisplayName("Tên Đồ Ăn")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? FoodName { get; set; }

        [DisplayName("Nhà Sản Xuất")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Manufacturer { get; set; }

        [Display(Name = "Ngày Sản Xuất")]
        [DataType(DataType.Date), DisplayName("Ngày Sản Xuất")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ManufacturingDate { get; set; }

        [DataType(DataType.Date), DisplayName("Hạn Sử Dụng")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }

        [DisplayName("Giá")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N0} VND", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DisplayName("Đánh Giá")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
