using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Search
{
    public interface ISearchService
    {
        Task<string> SearchByKeywords(string keywords, string searchPhrase);
    }
}
