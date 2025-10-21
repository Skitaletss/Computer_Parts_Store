using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Computer_Parts_Store.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }

        public override string ToString() => Name;
    }
}