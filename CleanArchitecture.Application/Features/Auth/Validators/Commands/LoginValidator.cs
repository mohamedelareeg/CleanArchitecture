using CleanArchitecture.Application.Features.Auth.Requests.Commands;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Application.Features.Auth.Validators.Commands
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator(IStringLocalizer<LoginValidator> localizer)
        {
            RuleFor(command => command.Email)
                .NotNull().WithMessage(localizer["EmailNotNull"])
                .NotEmpty().WithMessage(localizer["EmailNotEmpty"])
                .EmailAddress().WithMessage(localizer["InvalidEmail"])
                .MaximumLength(255).WithMessage(localizer["EmailMaxLength"]);

            RuleFor(command => command.Password)
                .NotNull().WithMessage(localizer["PasswordNotNull"])
                .NotEmpty().WithMessage(localizer["PasswordNotEmpty"])
                .MinimumLength(3).WithMessage(localizer["PasswordMinLength"])
                .Matches(@"^[^\s]+$").WithMessage(localizer["PasswordNoSpaces"])
                .MaximumLength(50).WithMessage(localizer["PasswordMaxLength"]);
        }
    }
}
