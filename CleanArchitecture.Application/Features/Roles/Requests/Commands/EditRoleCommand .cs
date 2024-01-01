using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Requests.Commands
{
    public class EditRoleCommand : IRequest<BaseResponse<string>>
    {
        public string RoleName { get; set; }
        public string NewRoleName { get; set; }
    }
}
