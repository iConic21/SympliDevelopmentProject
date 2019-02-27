using SympliDevelopmentProject.Services.Cache;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Engine
{
    public abstract class BaseEngineService : IBaseEngineService
    {
        private readonly ICacheService _cacheService;

        protected readonly string ValueGroupName = "cite";
        protected readonly string SearchUrlFormat;
        protected readonly string RegixSearchString = "<cite(.*?)>(.*?)(?'{0}'({1}))(.*?)<";
        private readonly HttpClient _httpClient;

        public BaseEngineService(ICacheService cacheService, string searchUrlFormat)
        {
            _cacheService = cacheService;
            SearchUrlFormat = searchUrlFormat;
            _httpClient = new HttpClient();
        }

        public BaseEngineService(ICacheService cacheService, string searchUrlFormat, string valueGroupName, string regixSearchString)
        {
            _cacheService = cacheService;
            ValueGroupName = valueGroupName;
            SearchUrlFormat = searchUrlFormat;
            RegixSearchString = regixSearchString;
            _httpClient = new HttpClient();
        }

        public virtual async Task<string> GetPage(string url)
        {
            var result = await _httpClient.GetAsync(url);
            return await result.Content.ReadAsStringAsync();
        }

        public virtual async Task<string> Search(string keywords, string phrase)
        {
            Regex htmlRegexExpression = new Regex(string.Format(RegixSearchString, ValueGroupName, phrase), RegexOptions.IgnoreCase | RegexOptions.Compiled);

            var keywordsList = keywords.Split(',');
            var tasks = new List<Task<int>>();
            foreach (var keyword in keywordsList)
            {
                tasks.Add(GetCount(htmlRegexExpression, keyword));
            }

            var results = await Task.WhenAll(tasks);
            return string.Join(",", results);
        }

        public virtual async Task<int> GetCount(Regex htmlRegexExpression, string keyword)
        {
            var cacheKey = $"{SearchUrlFormat}{htmlRegexExpression}{keyword}";
            var cache = _cacheService.Get<int?>(cacheKey);
            if (cache.HasValue)
            {
                return cache.Value;
            }

            var html = await GetPage(string.Format(SearchUrlFormat, keyword));
            var matches = htmlRegexExpression.Matches(html);
            var count = matches.Count;
            _cacheService.Set(cacheKey, count);
            return count;
        }
    }
}
