using BakoraAPI.Shared.DTOs.UserDTOs;
using BakoraAPI.Shared.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BakoraAPI.Shared.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{

    public LoginUserDtoValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(localizer["EmailRequired"])
            .EmailAddress()
            .WithMessage(localizer["EmailInvalid"]);

        RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(localizer["PasswordRequired"])
                .MinimumLength(8)
                .WithMessage(localizer["PasswordMinLength"])
                .Matches("[A-Z]").WithMessage(localizer["PasswordUppercaseRequired"])       // At least one uppercase
                .Matches("[a-z]").WithMessage(localizer["PasswordLowercaseRequired"])       // At least one lowercase
                .Matches("[0-9]").WithMessage(localizer["PasswordDigitRequired"])           // At least one digit
                .Matches("[^a-zA-Z0-9]").WithMessage(localizer["PasswordSpecialCharRequired"]); // At least one special char
    }
}
