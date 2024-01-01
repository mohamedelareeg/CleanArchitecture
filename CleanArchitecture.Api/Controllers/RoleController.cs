using CleanArchitecture.Api.Base;
using CleanArchitecture.Application.Features.Roles.Requests.Commands;
using CleanArchitecture.Application.Features.Roles.Requests.Queries;
using CleanArchitecture.Domain.AppMetaData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Authorize(Roles = "Administrator")]//Role
    [ApiController]
    public class RoleController : AppControllerBase
    {
        [HttpPost(Router.RoleRouting.Actions.CreateRole)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpPost(Router.RoleRouting.Actions.EditRole)]
        public async Task<IActionResult> EditRole([FromBody] EditRoleCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpPost(Router.RoleRouting.Actions.DeleteRole)]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpGet(Router.RoleRouting.Actions.GetRoleClaims)]
        public async Task<IActionResult> GetRoleClaims(string roleName)
        {
            var query = new GetRoleClaimsQuery { RoleName = roleName };
            return CustomResult(await Mediator.Send(query));
        }

        [HttpPost(Router.RoleRouting.Actions.AddClaimToRole)]
        public async Task<IActionResult> AddClaimToRole([FromBody] AddClaimToRoleCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }
        [HttpPost(Router.RoleRouting.Actions.AssignRoleToUser)]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleToUserCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpPost(Router.RoleRouting.Actions.AssignClaimToUser)]
        public async Task<IActionResult> AssignClaimToUser([FromBody] AssignClaimToUserCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpGet(Router.RoleRouting.Actions.GetUserRoles)]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var query = new GetUserRolesQuery { UserId = userId };
            return CustomResult(await Mediator.Send(query));
        }

        [HttpGet(Router.RoleRouting.Actions.GetUserClaims)]
        public async Task<IActionResult> GetUserClaims(string userId)
        {
            var query = new GetUserClaimsQuery { UserId = userId };
            return CustomResult(await Mediator.Send(query));
        }

        [HttpGet(Router.RoleRouting.Actions.GetAllRoles)]
        public async Task<IActionResult> GetAllRoles()
        {
            var query = new GetAllRolesQuery();
            return CustomResult(await Mediator.Send(query));
        }
        [HttpGet(Router.RoleRouting.Actions.GetAllClaims)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllClaims()
        {
            var query = new GetAllClaimsQuery();
            return CustomResult(await Mediator.Send(query));
        }
    }
}