using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Concrete
{
    public class ScheduledPostService : IScheduledPostService
    {
        private readonly IScheduledPostDal _scheduledPostDal;

        public ScheduledPostService(IScheduledPostDal scheduledPostDal)
        {
            _scheduledPostDal = scheduledPostDal;
        }

        public async Task Add(ScheduledPost scheduledPost)
        {
            await _scheduledPostDal.Add(scheduledPost);
        }

        public async Task Delete(int id)
        {
            var item = await _scheduledPostDal.Get(p => p.ScheduledPostId == id);
            await _scheduledPostDal.Delete(item);
        }

        public async Task<List<ScheduledPost>> GetAll()
        {
            return await _scheduledPostDal.GetList();
        }

        public async Task<ScheduledPost> GetById(int id)
        {
            return await _scheduledPostDal.Get(p => p.ScheduledPostId == id);
        }

        public async Task Update(ScheduledPost scheduledPost)
        {
            await _scheduledPostDal.Update(scheduledPost);
        }
    }
}
