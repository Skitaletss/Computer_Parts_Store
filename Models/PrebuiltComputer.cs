using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Computer_Parts_Store.Models
{
    public class PrebuiltComputer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [NotMapped]
        public decimal TotalPrice => Products?.Sum(p => p.Price) ?? 0;

        public PrebuiltComputer()
        {
            Products = new HashSet<Product>();
        }

        public override string ToString() => $"{Name} - {TotalPrice} грн";
    }
}