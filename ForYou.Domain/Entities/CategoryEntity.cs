namespace ForYou.Domain.Entities
{
    internal class CategoryEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
    }
}
