using System.ComponentModel.DataAnnotations;

namespace ForYou.Domain.Entities
{
    public class CategoryEntity : Entity
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public List<PostEntity> Posts { get; set; }
    }
}
