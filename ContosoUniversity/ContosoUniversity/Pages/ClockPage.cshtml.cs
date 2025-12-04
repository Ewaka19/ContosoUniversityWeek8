using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace ContosoUniversity.Pages
{
    public class ClockPageModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public DateTime CacheCurrentDateTime;
        public DateTime CurrentDateTime;
        private readonly ILogger<ClockPageModel> _logger;
        public ClockPageModel(ILogger<ClockPageModel> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }
        public void OnGet()
        {
            CurrentDateTime = DateTime.Now;

            if(!_memoryCache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue))
            {
                cacheValue = CurrentDateTime;

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));

                _memoryCache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
            }
            CacheCurrentDateTime = cacheValue;
            _logger.LogInformation("Cache created for cached time {cachedValue} at {Time}", cacheValue, DateTime.Now);
        }
    }
}
