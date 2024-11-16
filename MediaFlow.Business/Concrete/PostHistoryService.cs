using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Concrete
{
    public class PostHistoryService : IPostHistoryService
    {
        private readonly IPostHistoryDal _postHistoryDal;

        public PostHistoryService(IPostHistoryDal postHistoryDal)
        {
            _postHistoryDal = postHistoryDal;
        }

        public async Task Add(PostHistory postHistory)
        {
            await _postHistoryDal.Add(postHistory);
        }

        public async Task Delete(int id)
        {
            var item = await _postHistoryDal.Get(p => p.HistoryId == id);
            await _postHistoryDal.Delete(item);
        }

        public async Task<List<PostHistory>> GetAll()
        {
            return await _postHistoryDal.GetList();
        }

        public async Task<PostHistory> GetById(int id)
        {
            return await _postHistoryDal.Get(p => p.HistoryId == id);
        }

        public async Task Update(PostHistory postHistory)
        {
            await _postHistoryDal.Update(postHistory);
        }
    }
}
