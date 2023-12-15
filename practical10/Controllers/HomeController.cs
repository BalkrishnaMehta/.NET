using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace practical10.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 30)] 
        public IActionResult Index()
        {
            string cachedData;
            if (!_memoryCache.TryGetValue("cachedData", out cachedData!))
            {
                cachedData = $"Created at: {DateTime.Now}";
                _memoryCache.Set("cachedData", cachedData, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) 
                });
            }

            ViewBag.CachedData = cachedData;
            return View();
        }
    }
}