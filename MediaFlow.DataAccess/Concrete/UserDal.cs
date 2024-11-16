using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class UserDal : EFEntityFrameworkRepositoryBase<User, MediaFlowDbContext>, IUserDal
    {
        public UserDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
