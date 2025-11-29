using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Computer_Parts_Store.Models
{
    /// Клієнт магазину
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        // Історія замовлень клієнта
        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public override string ToString() => FullName;
    }
}