using MediaFlow.Core.DataAccess.EntityFramework;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.DataAccess.Concrete
{
    public class AnalyticsDal : EFEntityFrameworkRepositoryBase<Analytics, MediaFlowDbContext>, IAnalyticsDal
    {
        public AnalyticsDal(MediaFlowDbContext context)
            : base(context)
        {
        }
    }
}
