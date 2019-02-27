using SympliDevelopmentProject.Common;
using SympliDevelopmentProject.Services.Cache;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Engine
{
    public abstract class BaseEngineService : IBaseEngineService
    {
        private readonly ICacheService _cacheService;

        protected readonly string ValueGroupName;
        protected readonly string SearchUrlFormat;
        protected readonly string RegixSearchString;

        protected BaseEngineService(ICacheService cacheService, string valueGroupName, string searchUrlFormat, string regixSearchString)
        {
            _cacheService = cacheService;
            ValueGroupName = valueGroupName;
            SearchUrlFormat = searchUrlFormat;
            RegixSearchString = regixSearchString;
        }

        public virtual async Task<string> GetPage(string url)
        {
            try
            {
                var result = await Helpers.HttpClient.GetAsync(url);
                return await result.Content.ReadAsStringAsync();
            } catch
            {
                // TO-DO log using log4net
                return string.Empty;
            }
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
