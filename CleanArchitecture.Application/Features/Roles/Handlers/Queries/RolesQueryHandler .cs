using CleanArchitecture.Application.Bases;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Features.Roles.Requests.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Handlers.Queries
{
    public class RolesQueryHandler :
     IRequestHandler<GetUserRolesQuery, BaseResponse<IEnumerable<string>>>,
     IRequestHandler<GetUserClaimsQuery, BaseResponse<IEnumerable<string>>>,
     IRequestHandler<GetRoleClaimsQuery, BaseResponse<IEnumerable<string>>>,
     IRequestHandler<GetAllRolesQuery, BaseResponse<IEnumerable<string>>>,
     IRequestHandler<GetAllClaimsQuery, BaseResponse<IEnumerable<string>>>
    {
        private readonly IRoleService _roleService;

        public RolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<BaseResponse<IEnumerable<string>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetUserRoles(request.UserId);
            return result;
        }

        public async Task<BaseResponse<IEnumerable<string>>> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetUserClaims(request.UserId);
            return result;
        }

        public async Task<BaseResponse<IEnumerable<string>>> Handle(GetRoleClaimsQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetRoleClaims(request.RoleName);
            return result;
        }

        public async Task<BaseResponse<IEnumerable<string>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetAllRoles();
            return result;
        }

        public async Task<BaseResponse<IEnumerable<string>>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetAllClaims();
            return result;
        }
    }
}
