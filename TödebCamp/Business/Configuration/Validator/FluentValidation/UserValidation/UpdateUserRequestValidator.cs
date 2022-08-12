using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.UserValidation
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname can't be empty.");
            RuleFor(x => x.TcNo).NotEmpty().WithMessage("TC No can't be empty.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("please enter a valid email address.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phonenumber can't be empty.");


        }
    }
}
