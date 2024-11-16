using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class ContentPostDal : EFEntityFrameworkRepositoryBase<ContentPost, MediaFlowDbContext>, IContentPostDal
    {
        public ContentPostDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
