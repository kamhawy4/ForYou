using Microsoft.AspNetCore.Identity;

namespace ForYou.Domain.Entities
{
	public class UserEntity : IdentityUser
    {
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;

            public DateTime PublishedDate { get; set; }

            public List<PostEntity> Posts { get; set; }

            public List<CommentEntity> Comments { get; set; }

    }
}

