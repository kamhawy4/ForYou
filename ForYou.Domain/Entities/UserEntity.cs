using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ForYou.Domain.Entities
{
	public class UserEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public List<PostEntity> Posts { get; set; }  = null!;

        public List<CommentEntity> Comments { get; set; } = null!;


        [JsonIgnore]
        public string RefreshToken { get; set; } = "null";

        public DateTime RefreshTokenExpiryTime { get; set; } = DateTime.Now;


    }
}

