using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileManagementAPI.Helpers;

namespace UserProfileManagementAPI.Services.Configuration
{
    public static class JwtConfigurationExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer(x =>
           {
               x.Events = new JwtBearerEvents
               {
                   OnTokenValidated = context =>
                   {
                           var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                           var userId = Guid.Parse(context.Principal.Identity.Name);
                       var user = userService.GetById(userId);
                       if (user == null)
                       {
                               // return unauthorized if user no longer exists
                               context.Fail("Unauthorized");
                       }
                       return Task.CompletedTask;
                   }
               };
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
        }
    }
}
