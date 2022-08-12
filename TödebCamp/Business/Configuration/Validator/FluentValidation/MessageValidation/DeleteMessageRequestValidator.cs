using DTO.Message;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.MessageValidation
{
    public class DeleteMessageRequestValidator : AbstractValidator<DeleteMessageRequest>
    {
        public DeleteMessageRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");

        }
    }
}


