﻿using SympliDevelopmentProject.Services.Cache;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SympliDevelopmentProject.Services.Engine
{
    public abstract class BaseEngineService : IBaseEngineService
    {
        private readonly ICacheService _cacheService;

        public BaseEngineService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public virtual async Task<string> GetPage(string url)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(url);
            return await result.Content.ReadAsStringAsync();
        }

        public virtual async Task<string> Search(string regexString, string keywords)
        {
            Regex htmlRegexExpression = new Regex(regexString, RegexOptions.IgnoreCase | RegexOptions.Compiled);

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
            var cacheKey = GetCacheKey($"{htmlRegexExpression}{keyword}");
            var cache = _cacheService.Get<int?>(cacheKey);
            if (cache.HasValue)
            {
                return cache.Value;
            }

            var html = await GetPage(keyword);
            var matches = htmlRegexExpression.Matches(html);
            var count = matches.Count;
            _cacheService.Set(cacheKey, count);
            return count;
        }

        internal abstract string GetCacheKey(string value);
    }
}