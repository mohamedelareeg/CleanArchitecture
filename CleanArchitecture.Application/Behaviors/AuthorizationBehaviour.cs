using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace CleanArchitecture.Application.Behaviors
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUser _user;
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehaviour(
            IUser user,
            IIdentityService identityService,
            IHttpContextAccessor httpContextAccessor)
        {
            _user = user;
            _identityService = identityService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

                if (authorizeAttributes.Any())
                {
                    //var jwtToken = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                    //if (string.IsNullOrEmpty(jwtToken) || !await _identityService.ValidateToken(jwtToken))
                    //{
                    //    throw new UnauthorizedAccessException();
                    //}
                    // Must be authenticated user
                    if (_user.Id == null)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                    if (authorizeAttributesWithRoles.Any())
                    {
                        var authorized = false;

                        foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                        {
                            foreach (var role in roles)
                            {
                                var isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                                if (isInRole)
                                {
                                    authorized = true;
                                    break;
                                }
                            }
                        }

                        // Must be a member of at least one role in roles
                        if (!authorized)
                        {
                            throw new UnauthorizedAccessException();
                        }
                    }
                    // Claims-based authorization
                    var authorizeAttributesWithClaims = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Claims));
                    if (authorizeAttributesWithClaims.Any())
                    {
                        var authorized = false;

                        foreach (var claimTypeValuePairs in authorizeAttributesWithClaims.Select(a => a.Claims.Split(',')))
                        {
                            foreach (var claimTypeValuePair in claimTypeValuePairs)
                            {
                                var parts = claimTypeValuePair.Trim().Split(':');
                                if (parts.Length == 2)
                                {
                                    var claimType = parts[0];
                                    var claimValue = parts[1];

                                    var hasClaim = await _identityService.HasClaim(_user.Id, claimType, claimValue);
                                    if (hasClaim)
                                    {
                                        authorized = true;
                                        break;
                                    }
                                }
                            }
                        }

                        // Must have at least one required claim
                        if (!authorized)
                        {
                            throw new UnauthorizedAccessException();
                        }
                    }
                }

                // User is authorized / authorization not required
                return await next();
            }
            catch (Exception ex)
            {

                //_logger.LogError(ex, "An unexpected error occurred.");
                throw;
            }
        }
    }

}
