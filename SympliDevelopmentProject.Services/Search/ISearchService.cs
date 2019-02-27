using SympliDevelopmentProject.Common.Enums;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Search
{
    public interface ISearchService
    {
        Task<string> SearchByKeywords(SearchEngines searchEngine, string keywords, string searchPhrase);
    }
}
