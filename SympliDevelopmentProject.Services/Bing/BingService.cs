using SympliDevelopmentProject.Services.Cache;
using SympliDevelopmentProject.Services.Engine;

namespace SympliDevelopmentProject.Services.Bing
{
    public class BingService : BaseEngineService
    {
        private const string VALUE_GROUP_NAME = "cite";
        private const string SEARCH_URL_FORMAT = "https://www.bing.com/search?q={0}&count=100";
        private const string REGIX_SEARCH_STRING = "<cite(.*?)>(.*?)(?'{0}'({1}))(.*?)<";

        public BingService(ICacheService cacheService)
            : base(cacheService, VALUE_GROUP_NAME, SEARCH_URL_FORMAT, REGIX_SEARCH_STRING)
        {

        }
    }
}
