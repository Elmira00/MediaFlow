using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class UserSocialMediaAccount : IEntity
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public int PlatformId { get; set; }
        public string? AccountUsername { get; set; }
        public string? AuthToken { get; set; } // For API integration

        // Navigation Properties
        public User? User { get; set; }
        public SocialMediaPlatform? Platform { get; set; }
    }

}
