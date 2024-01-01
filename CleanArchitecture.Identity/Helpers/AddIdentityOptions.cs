using CleanArchitecture.Application.Models;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Identity.Helpers
{
    public static class AddIdentityOptions
    {
        public static void SetOptions(IServiceCollection services, DefaultIdentityOptions _DefaultIdentityOptions)
        {
            try
            {
                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = _DefaultIdentityOptions.PasswordRequireDigit;
                    options.Password.RequiredLength = _DefaultIdentityOptions.PasswordRequiredLength;
                    options.Password.RequireNonAlphanumeric = _DefaultIdentityOptions.PasswordRequireNonAlphanumeric;
                    options.Password.RequireUppercase = _DefaultIdentityOptions.PasswordRequireUppercase;
                    options.Password.RequireLowercase = _DefaultIdentityOptions.PasswordRequireLowercase;
                    options.Password.RequiredUniqueChars = _DefaultIdentityOptions.PasswordRequiredUniqueChars;

                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(_DefaultIdentityOptions.LockoutDefaultLockoutTimeSpanInMinutes);
                    options.Lockout.MaxFailedAccessAttempts = _DefaultIdentityOptions.LockoutMaxFailedAccessAttempts;
                    options.Lockout.AllowedForNewUsers = _DefaultIdentityOptions.LockoutAllowedForNewUsers;

                    options.User.RequireUniqueEmail = _DefaultIdentityOptions.UserRequireUniqueEmail;

                    options.SignIn.RequireConfirmedEmail = _DefaultIdentityOptions.SignInRequireConfirmedEmail;
                }).AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
