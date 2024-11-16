using MediaFlow.Entities.Models;

namespace MediaFlow.Core.Abstract
{
    public interface IContentPostService
    {
        Task<IEnumerable<ContentPost>> GetAllContentPostsAsync();
        Task<ContentPost> GetContentPostByIdAsync(int id);
        Task<ContentPost> CreateContentPostAsync(ContentPost contentPost);
        Task<bool> UpdateContentPostAsync(ContentPost contentPost);
        Task<bool> DeleteContentPostAsync(int id);
    }
}
