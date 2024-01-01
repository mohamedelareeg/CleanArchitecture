using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Requests.Commands
{
    public class CreateRoleCommand : IRequest<BaseResponse<string>>
    {
        public string RoleName { get; set; }
    }
}
