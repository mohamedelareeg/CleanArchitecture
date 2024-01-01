using CleanArchitecture.Application.Bases;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Features.Auth.Requests.Commands;
using CleanArchitecture.Application.Features.Auth.Results;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Domain.AppMetaData;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Identity.Services
{
    public class AuthService : BaseResponseHandler, IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IStringLocalizer<AuthService> _localizer;
        private readonly IdentityDbContext _identityDbContext;
        private readonly IEmailsService _emailsService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IStringLocalizer<BaseResponseHandler> localizer,
            IStringLocalizer<AuthService> authServiceLocalizer,
            IdentityDbContext identityDbContext,
            IEmailsService emailsService) : base(localizer)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _localizer = authServiceLocalizer;
            _identityDbContext = identityDbContext;
            _emailsService = emailsService;
        }

        public async Task<BaseResponse<LoginResult>> Login(LoginCommand request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return NotFound<LoginResult>(_localizer["UserNotFound"]);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return NotFound<LoginResult>(_localizer["InvalidCredentials", request.Email]);
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            LoginResult response = new LoginResult
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return Success(response);
        }

        public async Task<BaseResponse<RegisterResult>> Register(RegisterCommand request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                return Conflict<RegisterResult>(_localizer["UsernameExists", request.UserName]);
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return Created(new RegisterResult() { UserId = user.Id });
                }
                else
                {
                    return BadRequest<RegisterResult>(_localizer["BadRequestDetails"], result.Errors.Select(a => a.Description).ToList());
                }
            }
            else
            {
                return Conflict<RegisterResult>(_localizer["EmailExists", request.Email]);
            }
        }

        public async Task<BaseResponse<string>> SendResetPasswordCode(string email)
        {
            var trans = await _identityDbContext.Database.BeginTransactionAsync();

            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                    return NotFound<string>(_localizer["UserNotFound"]);

                var chars = "0123456789";
                var random = new Random();
                var randomNumber = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

                user.Code = randomNumber;

                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                    return BadRequest<string>(_localizer["ErrorInUpdateUser"]);

                var message = $"Code To Reset Password: {user.Code}";

                await _emailsService.SendEmail(user.Email, message, "Reset Password");

                await trans.CommitAsync();

                return Success<string>(_localizer["Success"]);
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return BadRequest<string>(_localizer["Failed"]);
            }
        }

        public async Task<BaseResponse<string>> ConfirmAndResetPassword(string code, string email, string newPassword)
        {
            using (var trans = await _identityDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                        return NotFound<string>(_localizer["UserNotFound"]);

                    var userCode = user.Code;

                    if (userCode == code)
                    {
                        // Code is valid, proceed to reset the password
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, newPassword);

                        await trans.CommitAsync();

                        return Success<string>(_localizer["PasswordResetSuccess"]);
                    }

                    return BadRequest<string>(_localizer["InvalidCode"]);
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return BadRequest<string>(_localizer["Failed"]);
                }
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

    }
}
