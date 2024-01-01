using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Requests.Commands
{
    public class AssignRoleToUserCommand : IRequest<BaseResponse<string>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
