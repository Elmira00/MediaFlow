using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class Account : IEntity
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public User? User { get; set; }
    }
}
