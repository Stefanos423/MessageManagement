using FluentValidation;
using MessageManagement.Models;

namespace MessageManagement.Validators
{
    public class AddMessageRequestValidator : AbstractValidator<AddMessageRequest>
    {
        public AddMessageRequestValidator()
        {
            RuleFor(request => request.Content).NotEmpty().MaximumLength(255);
        }
    }
}
