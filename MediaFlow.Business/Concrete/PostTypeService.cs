using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Concrete
{
    public class PostTypeService : IPostTypeService
    {
        private readonly IPostTypeDal _postTypeDal;

        public PostTypeService(IPostTypeDal postTypeDal)
        {
            _postTypeDal = postTypeDal;
        }

        public async Task Add(PostType postType)
        {
            await _postTypeDal.Add(postType);
        }

        public async Task Delete(int id)
        {
            var item = await _postTypeDal.Get(p => p.PostTypeId == id);
            await _postTypeDal.Delete(item);
        }

        public async Task<List<PostType>> GetAll()
        {
            return await _postTypeDal.GetList();
        }

        public async Task<PostType> GetById(int id)
        {
            return await _postTypeDal.Get(p => p.PostTypeId == id);
        }

        public async Task Update(PostType postType)
        {
            await _postTypeDal.Update(postType);
        }
    }
}
