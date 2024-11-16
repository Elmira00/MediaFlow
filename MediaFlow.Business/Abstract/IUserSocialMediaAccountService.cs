using MediaFlow.Entities.Models;

namespace MediaFlow.Business.Abstract
{
    public interface IUserSocialMediaAccountService
    {
        Task<List<UserSocialMediaAccount>> GetAll();
        Task Add(UserSocialMediaAccount account);
        Task Update(UserSocialMediaAccount account);
        Task Delete(int id);
        Task<UserSocialMediaAccount> GetById(int id);
    }
}
