using CleanArchitecture.Application.Bases;
using MediatR;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SendResetPasswordCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
    }
}
