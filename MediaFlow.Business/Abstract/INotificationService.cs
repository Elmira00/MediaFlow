using MediaFlow.Entities.Models;

namespace MediaFlow.Core.Abstract
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationsByUserId(int userId);
        Task<Notification> GetNotificationById(int id);
        Task<Notification> CreateNotification(Notification notification);
        Task<Notification> UpdateNotification(Notification notification);
        Task<bool> DeleteNotification(int id);
        Task<bool> SendNotificationToUser(int userId, string message);
    }
}
