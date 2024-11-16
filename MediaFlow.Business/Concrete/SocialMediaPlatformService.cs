using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.Models;
using MediaFlow.WebServerSide.Dtos;

namespace MediaFlow.WebServerSide.Services
{
    public class SocialMediaPlatformService : ISocialMediaPlatformService
    {
        private readonly ISocialMediaPlatformDal _platformDal;

        public SocialMediaPlatformService(ISocialMediaPlatformDal platformDal)
        {
            _platformDal = platformDal;
        }

        public async Task<IEnumerable<SocialMediaPlatform>> GetAllPlatforms()
        {
            return await _platformDal.GetList();
        }

        public async Task<SocialMediaPlatform> GetPlatformById(int id)
        {
            return await _platformDal.Get(p => p.PlatformId == id);
        }

        public async Task<SocialMediaPlatform> CreatePlatform(SocialMediaPlatformDto platformDto)
        {
            var platform = new SocialMediaPlatform
            {
                PlatformName = platformDto.PlatformName,
                ApiKey = platformDto.ApiKey,
                //   ApiSecret = platformDto.ApiSecret
            };

            await _platformDal.Add(platform);
            return platform;
        }

        public async Task<bool> UpdatePlatform(SocialMediaPlatformDto platformDto)
        {
            var platform = await _platformDal.Get(p => p.PlatformId == platformDto.PlatformId);
            if (platform == null)
                return false;

            platform.PlatformName = platformDto.PlatformName;
            platform.ApiKey = platformDto.ApiKey;
            //platform.ApiSecret = platformDto.ApiSecret;

            await _platformDal.Update(platform);
            return true;
        }

        public async Task<bool> DeletePlatform(int id)
        {
            var platform = await _platformDal.Get(p => p.PlatformId == id);
            if (platform == null)
                return false;

            await _platformDal.Delete(platform);
            return true;
        }
    }
}
