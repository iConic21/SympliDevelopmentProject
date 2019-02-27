using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> Get(string keywords, string searchPhrase)
        {
            return await _searchService.SearchByKeywords(keywords, searchPhrase);
        }
    }
}
