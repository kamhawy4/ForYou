namespace ForYou.Domain.Entities
{
    internal class CommentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
