using CleanArchitecture.Application.Contracts.Identity;

namespace CleanArchitecture.Application.Features.Auth.Handlers.Queries
{
    internal class AuthQueryHandler
    {
        private readonly IAuthService _authService;
        public AuthQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }


    }
}
