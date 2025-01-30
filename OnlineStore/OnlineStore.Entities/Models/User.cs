using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Entities.Models
{
    public class User : IdentityUser<int>, IEntity<int>
    {
        public string? FullName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<FavoriteProduct> FavoriteProducts { get; set; } = [];
    }
}
