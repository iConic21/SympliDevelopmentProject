using SympliDevelopmentProject.Services.Google;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly IGoogleService _googleService;

        public SearchService(IGoogleService googleService)
        {
            _googleService = googleService;
        }

        public async Task<string> SearchByKeywords(string keywords, string searchPhrase)
        {
            return await _googleService.Search(keywords, searchPhrase);
        }
    }
}
