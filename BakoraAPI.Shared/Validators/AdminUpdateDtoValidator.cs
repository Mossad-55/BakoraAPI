using BakoraAPI.Shared.DTOs.Admin;
using BakoraAPI.Shared.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BakoraAPI.Shared.Validators;
public class AdminUpdateDtoValidator : AbstractValidator<AdminUpdateDto>
{
    public AdminUpdateDtoValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(X => X.UserId)
            .NotEmpty()
            .WithMessage(localizer["IdRequired"]);

        RuleFor(x => x.FullNameEn)
            .NotEmpty()
            .WithMessage(localizer["FullNameRequired"]);

        RuleFor(x => x.FullNameAr)
            .NotEmpty()
            .WithMessage(localizer["FullNameRequired"]);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage(localizer["PhoneRequired"]);

        RuleFor(x => x.AddressEn)
            .NotEmpty()
            .WithMessage(localizer["AddressRequired"]);

        RuleFor(x => x.AddressAr)
            .NotEmpty()
            .WithMessage(localizer["AddressRequired"]);
    }
}
