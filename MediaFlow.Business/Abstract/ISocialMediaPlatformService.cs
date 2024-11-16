using MediaFlow.Entities.Models;
using MediaFlow.WebServerSide.Dtos;

namespace MediaFlow.WebServerSide.Services
{
    public interface ISocialMediaPlatformService
    {
        Task<IEnumerable<SocialMediaPlatform>> GetAllPlatforms();
        Task<SocialMediaPlatform> GetPlatformById(int id);
        Task<SocialMediaPlatform> CreatePlatform(SocialMediaPlatformDto platformDto);
        Task<bool> UpdatePlatform(SocialMediaPlatformDto platformDto);
        Task<bool> DeletePlatform(int id);
    }
}
