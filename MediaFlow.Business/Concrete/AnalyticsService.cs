using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Concrete
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IAnalyticsDal _analyticsDal;

        public AnalyticsService(IAnalyticsDal analyticsDal)
        {
            _analyticsDal = analyticsDal;
        }

        public async Task<IEnumerable<Analytics>> GetAllAsync()
        {
            return await _analyticsDal.GetList();
        }

        public async Task<Analytics?> GetByIdAsync(int id)
        {
            return await _analyticsDal.Get(a => a.AnalyticsId == id);
        }

        public async Task<Analytics> AddAsync(Analytics analytics)
        {
            await _analyticsDal.Add(analytics);
            return analytics;
        }

        public async Task<Analytics?> UpdateAsync(Analytics analytics)
        {
            await _analyticsDal.Update(analytics);
            return analytics;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var analytics = await _analyticsDal.Get(a => a.AnalyticsId == id);
            if (analytics == null) return false;

            await _analyticsDal.Delete(analytics);
            return true;
        }
    }
}
