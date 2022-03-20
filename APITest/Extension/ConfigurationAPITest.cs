using System.Security.Claims;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Tokens;

namespace APITest.Extension;

public static class ConfigurationAPITest
{
    public static IServiceCollection AddConfigurationAPITest(this IServiceCollection services)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5001";
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                };
                
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Apiscope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "api1");
            });
        });
        
        return services;
    }


}