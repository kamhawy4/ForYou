namespace ForYou.Domain.Entities
{
    internal class PostEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string CategoryId { get; set; } = null!;

    }
}
