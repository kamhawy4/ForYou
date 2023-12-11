namespace ForYou.Domain.Entities
{
    public class CategoryEntity : Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public List<PostEntity> Posts { get; set; }
    }
}
