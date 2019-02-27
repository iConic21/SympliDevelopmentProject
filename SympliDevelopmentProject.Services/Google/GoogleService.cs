using SympliDevelopmentProject.Services.Cache;
using SympliDevelopmentProject.Services.Engine;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Google
{
    public class GoogleService : BaseEngineService
    {
        private const string VALUE_GROUP_NAME = "cite";
        private const string SEARCH_URL_FORMAT = "https://www.google.com.au/search?q={0}&num=100";
        private const string REGIX_SEARCH_STRING = "<cite(.*?)>(.*?)(?'{0}'({1}))(.*?)<";

        public GoogleService(ICacheService cacheService) 
            : base(cacheService, VALUE_GROUP_NAME, SEARCH_URL_FORMAT, REGIX_SEARCH_STRING)
        {
            
        }
    }
}
