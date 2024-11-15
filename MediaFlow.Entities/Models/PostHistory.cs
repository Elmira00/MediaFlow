using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class PostHistory : IEntity
    {
        public int HistoryId { get; set; }
        public int PostId { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? PlatformResponse { get; set; } // Optional response from the social media API

        // Navigation Properties
        public ContentPost? ContentPost { get; set; }
    }

}
