using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Computer_Parts_Store.Models
{
    /// Елемент замовлення (товар у замовленні)
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        // Посилання на замовлення
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        // Посилання на товар
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int? PrebuiltComputerId { get; set; }
        [ForeignKey("PrebuiltComputerId")]
        public virtual PrebuiltComputer PrebuiltComputer { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // Ціна на момент покупки (фіксується)
        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;

        public override string ToString() => $"{Product?.Name ?? PrebuiltComputer.Name} x{Quantity} - {TotalPrice} грн";
    }
}