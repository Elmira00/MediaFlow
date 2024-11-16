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

        public async Task Add(Analytics analytics)
        {
            await _analyticsDal.Add(analytics);
        }

        public async Task Delete(int id)
        {
            var item = await _analyticsDal.Get(p => p.AnalyticsId == id);
            await _analyticsDal.Delete(item);
        }

        public async Task<List<Analytics>> GetAll()
        {
            return await _analyticsDal.GetList();
        }

        public async Task<Analytics> GetById(int id)
        {
            return await _analyticsDal.Get(p => p.AnalyticsId == id);
        }

        public async Task Update(Analytics analytics)
        {
            await _analyticsDal.Update(analytics);
        }
    }
}
