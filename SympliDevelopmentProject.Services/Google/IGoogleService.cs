using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Google
{
    public interface IGoogleService
    {
        Task<string> GetPage(string keyword);
        Task<string> Search(string keywords, string phrase);
    }
}