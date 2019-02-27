using SympliDevelopmentProject.Services.Google;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly GoogleService _googleService;

        public SearchService(GoogleService googleService)
        {
            _googleService = googleService;
        }

        public async Task<string> SearchByKeywords(string keywords, string searchPhrase)
        {
            return await _googleService.Search(keywords, searchPhrase);
        }
    }
}
