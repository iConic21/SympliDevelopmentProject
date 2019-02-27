using SympliDevelopmentProject.Services.Cache;
using SympliDevelopmentProject.Services.Engine;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Google
{
    public class GoogleService : BaseEngineService
    {
        public GoogleService(ICacheService cacheService) : base(cacheService)
        {
            ValueGroupName = "cite";
            SearchUrlFormat = "https://www.google.com.au/search?q={0}&num=100";
            RegixSearchString = "<cite(.*?)>(.*?)(?'{0}'({1}))(.*?)<";
        }
    }
}
