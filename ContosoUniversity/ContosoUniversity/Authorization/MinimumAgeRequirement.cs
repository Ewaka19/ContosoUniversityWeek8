using Microsoft.AspNetCore.Authorization;

namespace ContosoUniversity.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge) =>
            MinimumAge = minimumAge;

        public int MinimumAge { get; set; }
    }
}
