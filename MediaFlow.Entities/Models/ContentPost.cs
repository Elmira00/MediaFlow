using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class ContentPost : IEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int PlatformId { get; set; }
        public string? Content { get; set; }
        public int PostTypeId { get; set; }
        public string? Status { get; set; } // e.g., Scheduled, Posted
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User? User { get; set; }
        public SocialMediaPlatform? Platform { get; set; }
        public PostType? PostType { get; set; }
        public ICollection<ScheduledPost>? ScheduledPosts { get; set; }
        public ICollection<PostHistory>? PostHistories { get; set; }
        public ICollection<Analytics>? Analytics { get; set; }
    }

}
