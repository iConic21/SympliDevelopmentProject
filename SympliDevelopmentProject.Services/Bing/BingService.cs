using SympliDevelopmentProject.Services.Cache;
using SympliDevelopmentProject.Services.Engine;

namespace SympliDevelopmentProject.Services.Bing
{
    public class BingService : BaseEngineService
    {
        private const string SEARCH_URL_FORMAT = "https://www.bing.com/search?q={0}&count=100";

        public BingService(ICacheService cacheService)
            : base(cacheService, SEARCH_URL_FORMAT)
        {

        }
    }
}
