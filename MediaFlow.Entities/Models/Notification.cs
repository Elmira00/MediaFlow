using MediaFlow.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MediaFlow.Entities.Models
{
    public class Notification : IEntity
    {
        [Key]
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        // Navigation Properties
        public User? User { get; set; }
    }

}
