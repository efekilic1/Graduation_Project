using System.Linq;
using FluentValidation;


namespace Business.Configuration.Extensions
{
    public static class ValidatorExtension
    {
        public static void ThrowIfExeption(this FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid)
                return;
            var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
             throw new ValidationException(message);
            


        }
    }
}

