using DTO.Apartment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.ApartmentValidation
{
    public class CreateApartmentRequestValidator : AbstractValidator<CreateApartmentRequest>
    {
        public CreateApartmentRequestValidator()
        {
            RuleFor(x => x.BlockNo).InclusiveBetween(1, 2).WithMessage("Block No must be 1 or 2.");
            RuleFor(x => x.ApartmentNo).InclusiveBetween(1, 10).WithMessage("Apartment No must be between 1 and 10.");
            RuleFor(x => x.HouseType).NotEmpty().WithMessage("HouseType can't be empty.");
            RuleFor(x => x.Full).Must(x=> x == false || x == true).WithMessage("Full must be true or false.");
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0).WithMessage("UserId must be greater than 0."); ;
            RuleFor(x => x.HomeOwner).Must(x => x == false || x == true).WithMessage("HomeOwner must be true or false.");


        }
    }
}
