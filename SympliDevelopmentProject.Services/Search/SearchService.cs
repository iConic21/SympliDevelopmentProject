using SympliDevelopmentProject.Common.Enums;
using SympliDevelopmentProject.Services.Bing;
using SympliDevelopmentProject.Services.Engine;
using SympliDevelopmentProject.Services.Google;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly GoogleService _googleService;
        private readonly BingService _bingService;

        public SearchService(GoogleService googleService, BingService bingService)
        {
            _googleService = googleService;
            _bingService = bingService;
        }

        public async Task<string> SearchByKeywords(SearchEngines searchEngine, string keywords, string searchPhrase)
        {
            IBaseEngineService engine;

            switch (searchEngine)
            {
                case SearchEngines.Google:
                    engine = _googleService;
                    break;
                case SearchEngines.Bing:
                    engine = _bingService;
                    break;
                default:
                    throw new System.Exception("Cant find requested search engine");
            }

            return await engine.Search(keywords, searchPhrase);
        }
    }
}
