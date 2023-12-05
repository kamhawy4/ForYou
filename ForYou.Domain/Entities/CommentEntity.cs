namespace ForYou.Domain.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public Guid UserId { get; set; }
        public UserEntity Users { get; set; }

        public Guid PostId { get; set; }
        public PostEntity Posts { get; set; }

    }
}
