using BakoraAPI.Shared.DTOs.Service;
using BakoraAPI.Shared.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BakoraAPI.Shared.Validators;

public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
{
    public ServiceCreateDtoValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.TitleAr)
            .NotEmpty()
            .WithMessage(localizer["ServiceTitleAr"]);

        RuleFor(x => x.DescriptionAr)
            .NotEmpty()
            .WithMessage(localizer["ServiceDescriptionAr"]);

        RuleFor(x => x.TitleEn)
            .NotEmpty()
            .WithMessage(localizer["ServiceTitleEn"]);

        RuleFor(x => x.DescriptionEn)
            .NotEmpty()
            .WithMessage(localizer["ServiceDescriptionEn"]);
    }
}
