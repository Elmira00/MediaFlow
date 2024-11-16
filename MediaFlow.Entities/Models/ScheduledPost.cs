using MediaFlow.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MediaFlow.Entities.Models
{
    public class ScheduledPost : IEntity
    {
        [Key]
        public int ScheduledPostId { get; set; }
        public int PostId { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public bool IsRecurring { get; set; }
        public string? RecurrencePattern { get; set; } // e.g., daily, weekly
        public string? TimeZone { get; set; }

        // Navigation Properties
        public ContentPost? ContentPost { get; set; }
    }

}
