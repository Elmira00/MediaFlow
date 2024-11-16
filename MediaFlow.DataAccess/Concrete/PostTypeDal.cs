using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class PostTypeDal : EFEntityFrameworkRepositoryBase<PostType, MediaFlowDbContext>, IPostTypeDal
    {
        public PostTypeDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
