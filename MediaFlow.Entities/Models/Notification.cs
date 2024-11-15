using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class Notification : IEntity
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        // Navigation Properties
        public User? User { get; set; }
    }

}
