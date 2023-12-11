namespace ForYou.Domain.Entities
{
	public class UserEntity : Entity
    {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Mobile { get; set; } = null!;
            public string Password { get; set; } = null!;
            public DateTime PublishedDate { get; set; }

            public List<PostEntity> Posts { get; set; }

            public List<CommentEntity> Comments { get; set; }

    }
}

