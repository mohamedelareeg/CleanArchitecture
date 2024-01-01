// RolesCommandHandler.cs
using CleanArchitecture.Application.Bases;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Features.Roles.Requests.Commands;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Handlers
{
    public class RolesCommandHandler : IRequestHandler<CreateRoleCommand, BaseResponse<string>>,
                                       IRequestHandler<EditRoleCommand, BaseResponse<string>>,
                                       IRequestHandler<DeleteRoleCommand, BaseResponse<string>>,
                                       IRequestHandler<AddClaimToRoleCommand, BaseResponse<string>>,
                                       IRequestHandler<AssignRoleToUserCommand, BaseResponse<string>>,
                                       IRequestHandler<AssignClaimToUserCommand, BaseResponse<string>>
    {
        private readonly IRoleService _roleService;

        public RolesCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<BaseResponse<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.CreateRole(request);
        }

        public async Task<BaseResponse<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.EditRole(request);
        }

        public async Task<BaseResponse<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.DeleteRole(request);
        }

        public async Task<BaseResponse<string>> Handle(AddClaimToRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.AddClaimToRole(request);
        }

        public async Task<BaseResponse<string>> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.AddRoleToUser(request);
        }

        public async Task<BaseResponse<string>> Handle(AssignClaimToUserCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.AddClaimToUser(request);
        }
    }
}
