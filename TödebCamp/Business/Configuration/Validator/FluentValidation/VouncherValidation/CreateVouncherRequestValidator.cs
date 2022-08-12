

using DTO.User;
using DTO.Voucher;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.VouncherValidation
{
    public class CreateVouncherRequestValidator : AbstractValidator<CreateVoucherRequest>
    {
        public CreateVouncherRequestValidator()
        {
            RuleFor(x => x.BillId).GreaterThan(0).WithMessage("BillId must be greater than 0.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(x => x.CreditCardNumber).Length(16).WithMessage("Credit card must be 16 numbers.");
            RuleFor(x => x.Cvc).Length(3).WithMessage("Cvc must be 3 numbers.");
            


        }
    }
}
