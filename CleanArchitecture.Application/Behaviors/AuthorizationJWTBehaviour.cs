using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace CleanArchitecture.Application.Behaviors
{
    public class AuthorizationJWTBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUser _user;
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationJWTBehaviour(
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
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                var jwtToken = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (string.IsNullOrEmpty(jwtToken) || !await _identityService.ValidateToken(jwtToken))
                {
                    throw new UnauthorizedAccessException();
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}
