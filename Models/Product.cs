using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Computer_Parts_Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Article { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Specification { get; set; }
        public string? Color { get; set; }
        public string? Dimensions { get; set; }
        public decimal? Weight { get; set; }
        public int? WarrantyMonths { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<PrebuiltComputer> PrebuiltComputers { get; set; }

        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            PrebuiltComputers = new HashSet<PrebuiltComputer>();
        }

        public override string ToString() => $"{Name} ({Article}) - {Price} грн";
    }
}