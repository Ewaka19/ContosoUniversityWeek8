using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;

namespace ContosoUniversity.Pages
{
    public class DisplayDevAsModel : PageModel
    {

        private readonly IConfiguration Configuration;

        public string devloglevel;

        public DisplayDevAsModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void OnGet()
        {
            var loglevel = Configuration["Logging:LogLevel:Default"];
            devloglevel = $"Current default log level is: {loglevel}";
        }
    }
}
