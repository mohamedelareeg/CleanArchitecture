using CleanArchitecture.Api.Base;
using CleanArchitecture.Application.Features.Emails.Requests.Commands;
using CleanArchitecture.Domain.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{

    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.EmailsRoute.Actions.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            return CustomResult(await Mediator.Send(command));
        }
    }
}