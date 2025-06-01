using BakoraAPI.Shared.DTOs.Admin;
using BakoraAPI.Shared.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BakoraAPI.Shared.Validators;

public class AdminRegisterDtoValidator : AbstractValidator<AdminRegisterDto>
{
    public AdminRegisterDtoValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.FullNameEn)
            .NotEmpty()
            .WithMessage(localizer["FullNameRequired"]);

        RuleFor(x => x.FullNameAr)
            .NotEmpty()
            .WithMessage(localizer["FullNameRequired"]);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(localizer["EmailRequired"])
            .EmailAddress()
            .WithMessage(localizer["EmailInvalid"]);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage(localizer["PhoneRequired"]);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(localizer["PasswordRequired"])
            .MinimumLength(8)
            .WithMessage(localizer["PasswordMinLength"])
            .Matches("[A-Z]").WithMessage(localizer["PasswordUppercaseRequired"])       // At least one uppercase
            .Matches("[a-z]").WithMessage(localizer["PasswordLowercaseRequired"])       // At least one lowercase
            .Matches("[0-9]").WithMessage(localizer["PasswordDigitRequired"])           // At least one digit
            .Matches("[^a-zA-Z0-9]").WithMessage(localizer["PasswordSpecialCharRequired"]); // At least one special char

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage(localizer["PasswordMismatch"]);

        RuleFor(x => x.AddressEn)
            .NotEmpty()
            .WithMessage(localizer["AddressRequired"]);

        RuleFor(x => x.AddressAr)
            .NotEmpty()
            .WithMessage(localizer["AddressRequired"]);

        RuleFor(x => x.ProfilePicture)
            .NotNull()
            .WithMessage(localizer["ProfilePictureRequired"]);

        RuleFor(x => x.Role)
            .NotEmpty()
            .Must(role => role == RolesEnum.Admin.ToString())
            .WithMessage(localizer["RoleInvalid"]);
    }
}
