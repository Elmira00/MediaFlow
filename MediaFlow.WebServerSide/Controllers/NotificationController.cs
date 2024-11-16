using MediaFlow.Core.Abstract;
using MediaFlow.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // Get all notifications for a user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetNotificationsByUserId(int userId)
        {
            var notifications = await _notificationService.GetNotificationsByUserId(userId);
            if (notifications == null || notifications.Count == 0)
                return NotFound("No notifications found for this user.");

            return Ok(notifications);
        }

        // Get a single notification by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationById(id);
            if (notification == null)
                return NotFound("Notification not found.");

            return Ok(notification);
        }

        // Create a new notification
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] Notification notification)
        {
            if (notification == null)
                return BadRequest("Invalid notification data.");

            var createdNotification = await _notificationService.CreateNotification(notification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.NotificationId }, createdNotification);
        }

        // Update an existing notification
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] Notification notification)
        {
            if (id != notification.NotificationId)
                return BadRequest("Notification ID mismatch.");

            var updatedNotification = await _notificationService.UpdateNotification(notification);
            if (updatedNotification == null)
                return NotFound("Notification not found to update.");

            return Ok(updatedNotification);
        }

        // Delete a notification
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var result = await _notificationService.DeleteNotification(id);
            if (!result)
                return NotFound("Notification not found to delete.");

            return NoContent();
        }

        // Send a notification to a user (Optional)
        [HttpPost("send/{userId}")]
        public async Task<IActionResult> SendNotification(int userId, [FromBody] string message)
        {
            var result = await _notificationService.SendNotificationToUser(userId, message);
            if (!result)
                return BadRequest("Failed to send notification.");

            return Ok("Notification sent successfully.");
        }
    }
}
