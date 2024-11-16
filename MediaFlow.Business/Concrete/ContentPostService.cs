using MediaFlow.Core.Abstract;
using MediaFlow.DataAccess.Abstract; // Assuming DAL layer
using MediaFlow.Entities.Models;

namespace MediaFlow.Core.Concrete
{
    public class ContentPostService : IContentPostService
    {
        private readonly IContentPostDal _contentPostDal;

        public ContentPostService(IContentPostDal contentPostDal)
        {
            _contentPostDal = contentPostDal;
        }

        public async Task<IEnumerable<ContentPost>> GetAllContentPostsAsync()
        {
            return await _contentPostDal.GetList();
        }

        public async Task<ContentPost> GetContentPostByIdAsync(int id)
        {
            return await _contentPostDal.Get(c => c.PostId == id);
        }

        public async Task<ContentPost> CreateContentPostAsync(ContentPost contentPost)
        {
            await _contentPostDal.Add(contentPost);
            return contentPost;
        }

        public async Task<bool> UpdateContentPostAsync(ContentPost contentPost)
        {
            var existingPost = await _contentPostDal.Get(c => c.PostId == contentPost.PostId);
            if (existingPost == null)
            {
                return false; // Post not found
            }
            await _contentPostDal.Update(contentPost);
            return true;
        }

        public async Task<bool> DeleteContentPostAsync(int id)
        {
            var existingPost = await _contentPostDal.Get(c => c.PostId == id);
            if (existingPost == null)
            {
                return false; // Post not found
            }

            await _contentPostDal.Delete(existingPost);
            return true;
        }
    }
}
