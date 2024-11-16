using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class UserSocialMediaAccountDal : EFEntityFrameworkRepositoryBase<UserSocialMediaAccount, MediaFlowDbContext>, IUserSocialMediaAccountDal
    {
        public UserSocialMediaAccountDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
