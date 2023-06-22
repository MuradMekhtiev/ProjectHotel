using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestUpdateValidator : AbstractValidator<UpdateGuestDto>
    {
        public GuestUpdateValidator()
        {
            RuleFor(x => x.GuestName).NotNull().WithMessage("Please fill out this field.");
            RuleFor(x => x.GuestSurname).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.GuestName).MinimumLength(3).WithMessage("Minimum length for this field is 3 characters");
            RuleFor(x => x.GuestSurname).MinimumLength(3).WithMessage("Minimum length for this field is 3 characters");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Minimum length for this field is 3 characters");
            RuleFor(x => x.GuestName).MaximumLength(20).WithMessage("Maximum length for this field is 20 characters");
            RuleFor(x => x.GuestSurname).MaximumLength(30).WithMessage("Maximum length for this field is 30 characters");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Maximum length for this field is 20 characters");
        }
    }
}
