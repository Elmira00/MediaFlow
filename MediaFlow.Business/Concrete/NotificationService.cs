using MediaFlow.Core.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Core.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationService(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public async Task<List<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _notificationDal.GetList(n => n.UserId == userId);
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _notificationDal.Get(n => n.NotificationId == id);
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            // Add the notification to the database, but don't expect a return value.
            await _notificationDal.Add(notification);

            // Assuming the Add method doesn't return anything, we just return the notification.
            // This may not be ideal, but it depends on the DAL behavior.
            return notification;
        }



        public async Task<Notification> UpdateNotification(Notification notification)
        {
            // Update the notification in the database.
            await _notificationDal.Update(notification);

            // If the DAL method doesn't return anything, we assume it's been updated.
            // So we just return the notification object.
            return notification;
        }

        public async Task<bool> DeleteNotification(int id)
        {
            var notification = await _notificationDal.Get(n => n.NotificationId == id);
            if (notification == null)
                return false;

            await _notificationDal.Delete(notification);
            return true;
        }

        public async Task<bool> SendNotificationToUser(int userId, string message)
        {
            // You can implement the logic for sending notifications here
            // This could involve pushing messages to a messaging system, sending emails, etc.

            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                // SentAt = DateTime.UtcNow
            };

            await _notificationDal.Add(notification);
            return true;
        }
    }
}
