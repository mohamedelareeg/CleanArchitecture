using CleanArchitecture.Application.Bases;
using CleanArchitecture.Application.Features.Auth.Results;
using MediatR;

namespace CleanArchitecture.Application.Features.Auth.Requests.Commands
{
    public class LoginCommand : IRequest<BaseResponse<LoginResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
