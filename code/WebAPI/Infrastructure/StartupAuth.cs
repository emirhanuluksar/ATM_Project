using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Infrastructure;

public static class StartupAuth {
    public static void AddStartupAuthentication(this WebApplicationBuilder builder) {
        var appSettings = builder.Configuration.GetSection("AppSettings");
        var secretKey = Encoding.UTF8.GetBytes(appSettings["Secret"]);
        Console.WriteLine($"secretKey : {appSettings["Secret"]}");
        var hmac = new HMACSHA512(secretKey);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddCookie(options => {
                  options.LoginPath = "/Account/Unauthorized/";
                  options.AccessDeniedPath = "/Account/Forbidden/";
              })
              .AddJwtBearer(options => {
                  options.Audience = "uluars-admin-audience";
                  options.Authority = "";
                  options.TokenValidationParameters = new() {
                      ValidAudience = "clientid",
                      ValidIssuer = "clientid",
                      IssuerSigningKey = new SymmetricSecurityKey(hmac.Key),
                      ValidateAudience = false,
                      ValidateIssuerSigningKey = false,
                      ValidateIssuer = false,
                      SignatureValidator = (token, _) => new JwtSecurityToken(token)
                  };
              });
    }
    public static void AddStartupAuthorization(this WebApplicationBuilder builder) {
        // builder.Services.AddAuthorization(options => {
        //     options.AddPolicy(ClaimConstants.User, new AuthorizationPolicyBuilder()
        //         .RequireAuthenticatedUser()
        //         .RequireClaim(ClaimConstants.EmployeeNumber)
        //         .Build());
        //     options.AddPolicy(ClaimConstants.HasAdminRights, new AuthorizationPolicyBuilder()
        //         .RequireAuthenticatedUser()
        //         .RequireClaim(ClaimConstants.HasAdminRights, ClaimConstants.HasAdminRightsAdmin)
        //         .Build());
        // });
    }
}
