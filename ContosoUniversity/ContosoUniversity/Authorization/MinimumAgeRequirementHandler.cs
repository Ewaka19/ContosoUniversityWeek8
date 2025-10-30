using ContosoUniversity.Areas.Identity.Data;
using ContosoUniversity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ContosoUniversity.Authorization
{
    public class MinimumAgeRequirementHandler: AuthorizationHandler<MinimumAgeRequirement>
    {
        private readonly UserManager<ContosoUniversityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly ILogger<MinimumAgeRequirementHandler> _logger;
        public MinimumAgeRequirementHandler(
            UserManager<ContosoUniversityUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ILogger<MinimumAgeRequirementHandler> logger) 
        {
            _userManager = userManager;
            _httpContextAcessor = httpContextAccessor;
            _logger = logger;
            _logger.LogInformation("MinimumAgeRequirementHandler initialized.");
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var httpContext = _httpContextAcessor.HttpContext;
            var user = await _userManager.GetUserAsync(httpContext.User);

            _logger.LogInformation("Inside non-null verification ");

            if (user != null)
            {
                _logger.LogInformation("Inside non-null verification " + user.age);
                if (user.age >= requirement.MinimumAge)
                {
                    context.Succeed(requirement);
                }
            }
}
    }
}
