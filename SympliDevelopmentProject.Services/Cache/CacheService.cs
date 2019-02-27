using Microsoft.Extensions.Caching.Memory;
using System;

namespace SympliDevelopmentProject.Services.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Set<T>(string key, T value)
        {
            _memoryCache.Set(key, value, TimeSpan.FromHours(1));
        }
    }
}
