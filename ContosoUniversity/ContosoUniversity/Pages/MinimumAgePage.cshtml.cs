using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoUniversity.Pages
{
    [Authorize(Policy = "AtLeast21")]
    public class MinimumAgePageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
