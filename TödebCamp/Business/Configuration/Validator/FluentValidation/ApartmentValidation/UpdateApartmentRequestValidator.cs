using DTO.Apartment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.ApartmentValidation
{
    public class UpdateApartmentRequestValidator : AbstractValidator<UpdateApartmentRequest>
    {
        public UpdateApartmentRequestValidator()
        {
            RuleFor(x => x.ApartmentNo).InclusiveBetween(1, 10).WithMessage("Block no must be between 1 and 10.");
            RuleFor(x => x.HouseType).NotEmpty().WithMessage("HouseType can't be empty.");
            RuleFor(x => x.BlockNo).InclusiveBetween(1, 5).WithMessage("Block no must be between 1 and 5.");
            RuleFor(x => x.Full).Must(x => x == false || x == true).WithMessage("Full must be true or false.");
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0).WithMessage("UserId must be greater than 0."); ;
            RuleFor(x => x.HomeOwner).Must(x => x == false || x == true).WithMessage("HomeOwner must be true or false.");


        }
    }
}
