using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Concrete
{
    public class ContentPostService : IContentPostService
    {
        private readonly IContentPostDal _contentPostDal;

        public ContentPostService(IContentPostDal contentPostDal)
        {
            _contentPostDal = contentPostDal;
        }

        public async Task Add(ContentPost contentPost)
        {
            await _contentPostDal.Add(contentPost);
        }

        public async Task Delete(int id)
        {
            var item = await _contentPostDal.Get(p => p.PostId == id);
            await _contentPostDal.Delete(item);
        }

        public async Task<List<ContentPost>> GetAll()
        {
            return await _contentPostDal.GetList();
        }

        public async Task<ContentPost> GetById(int id)
        {
            return await _contentPostDal.Get(p => p.PostId == id);
        }

        public async Task Update(ContentPost contentPost)
        {
            await _contentPostDal.Update(contentPost);
        }
    }
}
