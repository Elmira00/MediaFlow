using MediaFlow.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MediaFlow.Entities.Models
{
    public class UserSocialMediaAccount : IEntity
    {
        [Key]
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
