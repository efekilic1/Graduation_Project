using DTO.Message;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.MessageValidation
{
    public class CreateMessageRequestValidator : AbstractValidator<CreateMessageRequest>
    {
        public CreateMessageRequestValidator()
        {
            RuleFor(x => x.MessageText).NotEmpty().WithMessage("Message can't be empty.");
            
        }
        
    }
}

