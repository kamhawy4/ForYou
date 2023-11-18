using Microsoft.AspNetCore.Http;

namespace ForYou.Domain.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public CategoryEntity CategoryEntity { get; set; }
        public Guid CategoryId { get; set; }

    }
}
