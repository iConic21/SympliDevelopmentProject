using System.Net.Http;

namespace SympliDevelopmentProject.Common
{
    public static class Helpers
    {
        public static HttpClient HttpClient;

        static Helpers()
        {
            HttpClient = new HttpClient();
        }
    }
}
