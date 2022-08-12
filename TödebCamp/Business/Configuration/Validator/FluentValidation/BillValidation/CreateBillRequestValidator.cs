using DTO.Bill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.BillValidation
{
    public class CreateBillRequestValidator : AbstractValidator<CreateBillRequest>
    {
        public CreateBillRequestValidator()
        {
            RuleFor(x => x.Month).IsInEnum().WithMessage("Month must be betweet 1 to 12.");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Type must be betweet 1 to 4. " +
                "ApartmentDues = 1, ElectricityBill = 2, NaturalgasBill = 3, WaterBill = 4 ");
            RuleFor(x => x.IsPaid).Must(x => x == false || x == true).WithMessage("IsPaid must be true or false.");
        }
    }
}


