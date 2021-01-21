using FluentValidation;
using FuncionalTest.Domain.Commands;

namespace FuncionalTest.Api.Validations
{
    public class SacarValidator : AbstractValidator<AccountCommand>
    {
        public SacarValidator()
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
