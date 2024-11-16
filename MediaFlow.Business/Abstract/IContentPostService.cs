using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IContentPostService
    {
        Task<List<ContentPost>> GetAll();
        Task Add(ContentPost contentPost);
        Task Update(ContentPost contentPost);
        Task Delete(int id);
        Task<ContentPost> GetById(int id);
    }
}
