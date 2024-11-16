using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class ScheduledPostDal : EFEntityFrameworkRepositoryBase<ScheduledPost, MediaFlowDbContext>, IScheduledPostDal
    {
        public ScheduledPostDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
