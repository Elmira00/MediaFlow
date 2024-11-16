using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IAnalyticsService
    {
        Task<IEnumerable<Analytics>> GetAllAsync();
        Task<Analytics?> GetByIdAsync(int id);
        Task<Analytics> AddAsync(Analytics analytics);
        Task<Analytics?> UpdateAsync(Analytics analytics);
        Task<bool> DeleteAsync(int id);
    }
}
