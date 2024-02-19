using System.ComponentModel.DataAnnotations;

namespace ForYou.Domain.Entities
{
    public class CommentEntity : Entity
    {
        [Key]
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public string CommentName { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public Guid UserId { get; set; }
        public UserEntity Users { get; set; }

        public Guid PostId { get; set; }
        public PostEntity Posts { get; set; }

    }
}
