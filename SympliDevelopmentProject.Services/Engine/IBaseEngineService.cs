using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Engine
{
    public interface IBaseEngineService
    {
        Task<int> GetCount(Regex htmlRegexExpression, string keyword);
        Task<string> GetPage(string url);
        Task<string> Search(string regexString, string keywords);
    }
}