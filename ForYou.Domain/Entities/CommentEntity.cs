namespace ForYou.Domain.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public string UserId { get; set; }
        public UserEntity UserEntity { get; set; }


    }
}
