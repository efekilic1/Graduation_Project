using DTO.User;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.UserValidation
{
    public class CreateUserRegisterRequestValidator : AbstractValidator<CreateUserRegisterRequest>
    {
        public CreateUserRegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname can't be empty.");
            RuleFor(x => x.TcNo).NotEmpty().WithMessage("TC No can't be empty.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("please enter a valid email address.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phonenumber can't be empty.");
            RuleFor(x => x.UserPassword).Length(6).Equal(x => x.ConfirmPassword).WithMessage("Confirm Password can't be different to password and lengt must be 6 characters.");



        }
    }
}
