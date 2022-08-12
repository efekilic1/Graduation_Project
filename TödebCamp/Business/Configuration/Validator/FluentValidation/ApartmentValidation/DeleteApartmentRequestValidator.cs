using DTO.Apartment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.ApartmentValidation
{
    public class DeleteApartmentRequestValidator : AbstractValidator<DeleteApartmentRequest>
    {
        public DeleteApartmentRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            


        }
    }
}
