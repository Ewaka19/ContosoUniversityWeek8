using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoUniversity.Pages
{
    [ResponseCache(Duration = 7200, Location = ResponseCacheLocation.Any, NoStore = false)]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public DateTime cachedTime { get; set; }
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            cachedTime = DateTime.Now;
            _logger.LogInformation("Cache created for Key {cachedTime} at {Time}", cachedTime, DateTime.Now);
        }
    }

}
