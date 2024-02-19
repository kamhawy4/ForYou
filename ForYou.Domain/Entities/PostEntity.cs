using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ForYou.Domain.Entities
{
    public class PostEntity: Entity
    {
        [Key]
        public Guid PostId { get; set; } 
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Image { get; set; } = null!;

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid CategoryId { get; set; }
         

        public CategoryEntity Category { get; set; }


        public Guid CommentId { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public DateTime PublishedDate { get; set; }


    }
}
