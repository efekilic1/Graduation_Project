using System;
using Business.Abstract;
using Microsoft.Extensions.Caching.Distributed;

namespace Business.Concrete
{
    // Logic işlemlerimizi, validasyonlarımızı yaptığımız business katmanı

    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void DistSetString(string key, string value)
        {
            _distributedCache.SetString(key, value);
        }

        public void DistSetList(string key)
        {
            var arrayNumber = new int[] { 1, 2, 4, 6 };
            var strArrayNumber = System.Text.Json.JsonSerializer.Serialize(arrayNumber);
            _distributedCache.SetString(key, strArrayNumber);
        }

    }
}
