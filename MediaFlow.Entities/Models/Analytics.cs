using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class Analytics : IEntity
    {
        public int AnalyticsId { get; set; }
        public int PostId { get; set; }  // Foreign Key to ContentPost
        public int PlatformId { get; set; }  // Foreign Key to SocialMediaPlatform
        public int Likes { get; set; }  // Total Likes count
        public int Comments { get; set; }  // Total Comments count
        public int Shares { get; set; }  // Total Shares count
        public int Impressions { get; set; }  // Total Impressions count
        public double EngagementRate { get; set; }  // Engagement rate (Likes + Comments + Shares) / Impressions

        // Navigation Properties
        public ContentPost? ContentPost { get; set; }
        public SocialMediaPlatform? Platform { get; set; }
    }

}
