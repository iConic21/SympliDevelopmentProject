using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SympliDevelopmentProject.Common.Enums;
using SympliDevelopmentProject.Services.Search;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SympliDevelopmentProject.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<string> Search(SearchEngines searchEngine, string keywords, string searchPhrase)
        {
            return await _searchService.SearchByKeywords(searchEngine, keywords, searchPhrase);
        }

        [HttpGet, Route("google")]
        public async Task<string> SearchGoogle(string keywords, string searchPhrase)
        {
            return await Search(SearchEngines.Google, keywords, searchPhrase);
        }

        [HttpGet, Route("bing")]
        public async Task<string> SearchBing(string keywords, string searchPhrase)
        {
            return await Search(SearchEngines.Bing, keywords, searchPhrase);
        }
    }
}
