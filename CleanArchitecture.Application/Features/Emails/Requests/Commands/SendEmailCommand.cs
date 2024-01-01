using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Emails.Requests.Commands
{
    public class SendEmailCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
