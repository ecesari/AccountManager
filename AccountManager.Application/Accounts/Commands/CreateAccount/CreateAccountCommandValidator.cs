using FluentValidation;

namespace AccountManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(v => v.InitialCredit).GreaterThanOrEqualTo(0).WithMessage("Initial credit cannot be lowered than 0");
            RuleFor(v => v.CustomerId).NotNull().WithMessage("Customer Id cannot be null");            
        }
    }
}