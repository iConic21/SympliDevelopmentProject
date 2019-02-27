using SympliDevelopmentProject.Services.Cache;
using SympliDevelopmentProject.Services.Engine;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Google
{
    public class GoogleService : BaseEngineService, IGoogleService
    {
        private const string VALUE_GROUP_NAME = "cite";
        private const string SEARCH_URL_FORMAT = "https://www.google.com.au/search?q={0}&num=100";
        private const string REGIX_SEARCH_STRING = "<cite(.*?)>(.*?)(?'{0}'({1}))(.*?)<";

        public GoogleService(ICacheService cacheService) : base(cacheService)
        {
        }

        public override async Task<string> GetPage(string keyword)
        {
            return await base.GetPage(string.Format(SEARCH_URL_FORMAT, keyword));
        }

        public override async Task<string> Search(string keywords, string phrase)
        {
            return await base.Search(string.Format(REGIX_SEARCH_STRING, VALUE_GROUP_NAME, phrase), keywords);
        }

        internal override string GetCacheKey(string value)
        {
            return $"{SEARCH_URL_FORMAT}{value}";
        }
    }
}
