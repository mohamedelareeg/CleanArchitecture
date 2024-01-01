using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Helpers;
using CleanArchitecture.Identity.Helpers.Filters;
using CleanArchitecture.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.Identity
{
    public static class IdentityDependencies
    {
        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<IdentityDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
      b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)),
      ServiceLifetime.Scoped);


            services.AddScoped<IEmailsService, EmailsService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUser, CurrentUser>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(o =>
             {
                 o.RequireHttpsMetadata = false;
                 o.SaveToken = true;
                 o.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidIssuer = configuration["JwtSettings:Issuer"],
                     ValidAudience = configuration["JwtSettings:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                 };
             });
            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(emailSettings);

            ////////////////////////////////////////////////////////Authorization//////////////////////////////////////////
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();//one instance
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
            ////////////////////////////////////////////////////////END//////////////////////////////////////////////////////
            IConfigurationSection _IConfigurationSection = configuration.GetSection("IdentityDefaultOptions");
            services.Configure<DefaultIdentityOptions>(_IConfigurationSection);
            var _DefaultIdentityOptions = _IConfigurationSection.Get<DefaultIdentityOptions>();
            AddIdentityOptions.SetOptions(services, _DefaultIdentityOptions);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            // .AddJwtBearer(o =>
            // {
            //     o.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         ValidateIssuer = true,
            //         ValidateAudience = true,
            //         ValidateLifetime = true,
            //         ClockSkew = TimeSpan.Zero,
            //         ValidIssuer = configuration["JwtSettings:Issuer"],
            //         ValidAudience = configuration["JwtSettings:Audience"],
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //     };
            // });
            return services;
        }
    }
}
