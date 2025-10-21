using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Computer_Parts_Store.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Нове";

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [NotMapped]
        public decimal TotalAmount => OrderItems?.Sum(oi => oi.TotalPrice) ?? 0;

        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public override string ToString() => $"Замовлення #{Id} - {TotalAmount} грн";
    }
}