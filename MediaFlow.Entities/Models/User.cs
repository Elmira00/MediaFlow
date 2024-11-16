using MediaFlow.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MediaFlow.Entities.Models
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<UserSocialMediaAccount>? SocialMediaAccounts { get; set; }
        public ICollection<ContentPost>? ContentPosts { get; set; }
    }

}
