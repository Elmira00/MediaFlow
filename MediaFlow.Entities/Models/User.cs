using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<UserSocialMediaAccount>? SocialMediaAccounts { get; set; }
        public ICollection<ContentPost>? ContentPosts { get; set; }
    }

}
