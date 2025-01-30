using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Entities.Models
{
    public class Product : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
