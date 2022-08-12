using DTO.Bill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.BillValidation
{
    public class DeleteBillRequestValidator : AbstractValidator<DeleteBillRequest>
    {
        public DeleteBillRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            
        }
    }
}


