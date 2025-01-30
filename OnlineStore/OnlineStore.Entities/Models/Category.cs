using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Entities.Models
{
    public class Category : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
