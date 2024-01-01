using CleanArchitecture.Api.Base;
using CleanArchitecture.Application.Features.Auth.Requests.Commands;
using CleanArchitecture.Domain.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace CleanArchitecture.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AuthController : AppControllerBase
    {

        [HttpPost(Router.AuthRouting.Actions.Login)]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpPost(Router.AuthRouting.Actions.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            return CustomResult(await Mediator.Send(request));
        }

        [HttpPost(Router.AuthRouting.Actions.SendResetPasswordCode)]
        public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CustomResult(response);
        }
        [HttpPost(Router.AuthRouting.Actions.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CustomResult(response);
        }
    }
}