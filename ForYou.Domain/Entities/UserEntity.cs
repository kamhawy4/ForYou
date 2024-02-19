using Microsoft.AspNetCore.Identity;

namespace ForYou.Domain.Entities
{
	public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public DateTime PublishedDate { get; set; }

        public List<PostEntity> Posts { get; set; }

        public List<CommentEntity> Comments { get; set; }

    }
}

