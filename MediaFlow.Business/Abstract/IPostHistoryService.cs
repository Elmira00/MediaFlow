using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IPostHistoryService
    {
        Task<List<PostHistory>> GetAll();
        Task Add(PostHistory postHistory);
        Task Update(PostHistory postHistory);
        Task Delete(int id);
        Task<PostHistory> GetById(int id);
    }
}
