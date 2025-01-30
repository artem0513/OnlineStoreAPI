using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Dtos
{
    public class UpsertCategoryDto : BaseDto<int>
    {
        [Required, MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<int> ProductIds { get; set; }
    }
}
