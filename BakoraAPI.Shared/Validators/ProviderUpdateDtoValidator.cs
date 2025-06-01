using BakoraAPI.Shared.DTOs.Provider;
using BakoraAPI.Shared.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BakoraAPI.Shared.Validators;

public class ProviderUpdateDtoValidator : AbstractValidator<ProviderUpdateDto>
{
    public ProviderUpdateDtoValidator(IStringLocalizer<SharedResource> localizer)
    {
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

        RuleFor(x => x.InstitutionNameEn)
            .NotEmpty()
            .WithMessage(localizer["InstitutionNameEn"]);

        RuleFor(x => x.InstitutionNameAr)
            .NotEmpty()
            .WithMessage(localizer["InstitutionNameAr"]);

        RuleFor(x => x.InstitutionTypeEn)
            .NotEmpty()
            .WithMessage(localizer["InstitutionTypeEn"]);

        RuleFor(x => x.InstitutionTypeAr)
            .NotEmpty()
            .WithMessage(localizer["InstitutionTypeAr"]);

        RuleFor(x => x.CommercialRegistrationNumber)
            .NotEmpty()
            .WithMessage(localizer["CommercialRegistrationNumber"]);

        RuleFor(x => x.CommercialRegistrationDate)
            .NotEmpty()
            .NotNull()
            .WithMessage(localizer["CommercialRegistrationDate"]);

        RuleFor(X => X.UserId)
            .NotEmpty()
            .WithMessage(localizer["IdRequired"]);

    }
}
