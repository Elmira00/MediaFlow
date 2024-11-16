using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IAnalyticsService
    {
        Task<List<Analytics>> GetAll();
        Task Add(Analytics analytics);
        Task Update(Analytics analytics);
        Task Delete(int id);
        Task<Analytics> GetById(int id);
    }
}
