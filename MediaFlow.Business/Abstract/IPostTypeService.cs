using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IPostTypeService
    {
        Task<List<PostType>> GetAll();
        Task Add(PostType postType);
        Task Update(PostType postType);
        Task Delete(int id);
        Task<PostType> GetById(int id);
    }
}
