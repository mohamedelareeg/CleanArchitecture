namespace CleanArchitecture.Application.Contracts.Identity
{
    public interface IIdentityService
    {
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<bool> HasClaim(string userId, string claimType, string claimValue);

        Task<bool> ValidateToken(string token);

    }
}
