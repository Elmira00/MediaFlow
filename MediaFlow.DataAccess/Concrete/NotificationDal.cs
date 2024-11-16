using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class NotificationDal : EFEntityFrameworkRepositoryBase<Notification, MediaFlowDbContext>, INotificationDal
    {
        public NotificationDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
