using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TestProject.API.Extensions;

public static class AuthorizationServiceExtension
{
    public static void AuthorizationPolicy(this IServiceCollection services)
    {
        services.AddMvc(cfg =>
        {
            cfg.EnableEndpointRouting = false;
            AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            cfg.Filters.Add(new AuthorizeFilter(policy));
        }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UP-USER",
            policy => policy.RequireClaim("permissions", "UP-USER"));
        });
    }
}