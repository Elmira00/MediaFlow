using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class PostHistoryDal : EFEntityFrameworkRepositoryBase<PostHistory, MediaFlowDbContext>, IPostHistoryDal
    {
        public PostHistoryDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
