using CleanArchitecture.Application.Bases;
using MediatR;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
}
