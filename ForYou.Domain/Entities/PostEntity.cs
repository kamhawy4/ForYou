namespace ForYou.Domain.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public string CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }

    }
}
