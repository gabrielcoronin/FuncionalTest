using FluentValidation;
using FuncionalTest.Domain.REST.Commands;

namespace FuncionalTest.Api.Validations
{
    public class DepositarValidator : AbstractValidator<AccountCommand>
    {
        public DepositarValidator()
        {
            RuleFor(c => c.Account.Id)
               .Must(c => c != null)
               .WithMessage("Id necessário");

            RuleFor(c => c.Valor)
               .GreaterThan(0)
               .WithMessage("Valor necessário");
        }
    }
}
