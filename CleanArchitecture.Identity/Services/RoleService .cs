using CleanArchitecture.Application.Bases;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Features.Roles.Requests.Commands;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Identity.Services
{
    public class RoleService : BaseResponseHandler, IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<RoleService> _localizer;
        private readonly IUser _user;

        public RoleService(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IStringLocalizer<RoleService> localizer,
            IUser user)
            : base(localizer)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _localizer = localizer;
            _user = user;
        }

        public async Task<BaseResponse<string>> CreateRole(CreateRoleCommand request)
        {
            var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);
            if (roleExist)
            {
                return BadRequest<string>(_localizer["RoleExists", request.RoleName]);
            }

            var role = new IdentityRole(request.RoleName);
            var result = await _roleManager.CreateAsync(role);

            return result.Succeeded
                ? Success<string>(_localizer["RoleCreatedSuccessfully", request.RoleName])
                : BadRequest<string>(_localizer["ErrorCreatingRole", request.RoleName]);
        }

        public async Task<BaseResponse<string>> EditRole(EditRoleCommand request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                return BadRequest<string>(_localizer["RoleNotFound", request.RoleName]);
            }

            role.Name = request.NewRoleName;
            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded
                ? Success<string>(_localizer["RoleUpdatedSuccessfully", request.NewRoleName])
                : BadRequest<string>(_localizer["ErrorUpdatingRole", request.NewRoleName]);
        }

        public async Task<BaseResponse<string>> DeleteRole(DeleteRoleCommand request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                return BadRequest<string>(_localizer["RoleNotFound", request.RoleName]);
            }

            var result = await _roleManager.DeleteAsync(role);

            return result.Succeeded
                ? Success<string>(_localizer["RoleDeletedSuccessfully", role.Name])
                : BadRequest<string>(_localizer["ErrorDeletingRole", role.Name]);
        }

        public async Task<BaseResponse<string>> AddClaimToRole(AddClaimToRoleCommand request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                return BadRequest<string>(_localizer["RoleNotFound", request.RoleName]);
            }

            var user = await _userManager.FindByIdAsync(_user.Id);
            if (user == null)
            {
                return BadRequest<string>(_localizer["UserNotFound", _user.Id]);
            }

            var result = await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(request.ClaimType, request.ClaimValue));

            return result.Succeeded
                ? Success<string>(_localizer["ClaimAddedSuccessfully", request.ClaimType, request.ClaimValue, role.Name])
                : BadRequest<string>(_localizer["ErrorAddingClaim", role.Name]);
        }
        public async Task<BaseResponse<IEnumerable<string>>> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest<IEnumerable<string>>(_localizer["UserNotFound", userId]);
            }

            var roles = await _userManager.GetRolesAsync(user);
            return Success<IEnumerable<string>>(roles);
        }

        public async Task<BaseResponse<IEnumerable<string>>> GetUserClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest<IEnumerable<string>>(_localizer["UserNotFound", userId]);
            }

            var claims = await _userManager.GetClaimsAsync(user);
            return Success<IEnumerable<string>>(claims.Select(a => a.Value).ToList());
        }

        public async Task<BaseResponse<IEnumerable<string>>> GetRoleClaims(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return BadRequest<IEnumerable<string>>(_localizer["RoleNotFound", roleName]);
            }

            var claims = await _roleManager.GetClaimsAsync(role);
            return Success<IEnumerable<string>>(claims.Select(c => $"{c.Type}:{c.Value}"));
        }

        public async Task<BaseResponse<IEnumerable<string>>> GetAllRoles()
        {
            var roles = await Task.FromResult(_roleManager.Roles.Select(r => r.Name));
            return Success<IEnumerable<string>>(roles);
        }

        public async Task<BaseResponse<IEnumerable<string>>> GetAllClaims()
        {
            var user = await _userManager.FindByEmailAsync(_user.Id);
            if (user == null)
            {
                return BadRequest<IEnumerable<string>>(_localizer["UserNotFound", _user.Id]);
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = userClaims.Select(claim => $"{claim.Type}:{claim.Value}");

            return Success(claims);
        }


        public async Task<BaseResponse<string>> AddRoleToUser(AssignRoleToUserCommand request)
        {
            var user = await _userManager.FindByEmailAsync(request.UserId);
            if (user == null)
            {
                return BadRequest<string>(_localizer["UserNotFound", request.UserId]);
            }

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);

            return result.Succeeded
                ? Success<string>(_localizer["RoleAssignedSuccessfully", request.RoleName, user.UserName])
                : BadRequest<string>(_localizer["ErrorAssigningRole", request.RoleName, user.UserName]);
        }

        public async Task<BaseResponse<string>> AddClaimToUser(AssignClaimToUserCommand request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return BadRequest<string>(_localizer["UserNotFound", request.UserId]);
            }

            var result = await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(request.ClaimType, request.ClaimValue));

            return result.Succeeded
                ? Success<string>(_localizer["ClaimAddedSuccessfully", request.ClaimType, request.ClaimValue, user.UserName])
                : BadRequest<string>(_localizer["ErrorAddingClaim", user.UserName]);
        }


    }
}
