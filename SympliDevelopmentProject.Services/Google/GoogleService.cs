using SympliDevelopmentProject.Services.Cache;
using SympliDevelopmentProject.Services.Engine;

namespace SympliDevelopmentProject.Services.Google
{
    public class GoogleService : BaseEngineService
    {
        private const string SEARCH_URL_FORMAT = "https://www.google.com.au/search?q={0}&num=100";

        public GoogleService(ICacheService cacheService) 
            : base(cacheService, SEARCH_URL_FORMAT)
        {
            
        }
    }
}
