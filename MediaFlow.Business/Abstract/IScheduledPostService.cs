using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IScheduledPostService
    {
        Task<List<ScheduledPost>> GetAll();
        Task Add(ScheduledPost scheduledPost);
        Task Update(ScheduledPost scheduledPost);
        Task Delete(int id);
        Task<ScheduledPost> GetById(int id);
    }
}
