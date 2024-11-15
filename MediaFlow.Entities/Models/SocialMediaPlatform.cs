using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class SocialMediaPlatform : IEntity
    {
        public int PlatformId { get; set; }
        public string? PlatformName { get; set; }
        public string? ApiKey { get; set; } // Optional for API credentials

        // Navigation Properties
        public ICollection<UserSocialMediaAccount>? UserAccounts { get; set; }
        public ICollection<ContentPost>? ContentPosts { get; set; }
        public ICollection<Analytics>? Analytics { get; set; }
    }

}
