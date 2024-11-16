using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class SocialMediaPlatformDal : EFEntityFrameworkRepositoryBase<SocialMediaPlatform, MediaFlowDbContext>, ISocialMediaPlatformDal
    {
        public SocialMediaPlatformDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
