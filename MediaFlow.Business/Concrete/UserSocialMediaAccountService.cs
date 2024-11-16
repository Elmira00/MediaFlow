using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Concrete
{
    public class UserSocialMediaAccountService : IUserSocialMediaAccountService
    {
        private readonly IUserSocialMediaAccountDal _accountDal;

        public UserSocialMediaAccountService(IUserSocialMediaAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public async Task Add(UserSocialMediaAccount account)
        {
            await _accountDal.Add(account);
        }

        public async Task Delete(int id)
        {
            var item = await _accountDal.Get(p => p.AccountId == id);
            await _accountDal.Delete(item);
        }

        public async Task<List<UserSocialMediaAccount>> GetAll()
        {
            return await _accountDal.GetList();
        }

        public async Task<UserSocialMediaAccount> GetById(int id)
        {
            return await _accountDal.Get(p => p.AccountId == id);
        }

        public async Task Update(UserSocialMediaAccount account)
        {
            await _accountDal.Update(account);
        }
    }
}
