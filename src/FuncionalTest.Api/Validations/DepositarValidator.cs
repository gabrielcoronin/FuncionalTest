using FluentValidation;
using FuncionalTest.Api.ViewModels;

namespace FuncionalTest.Api.Validations
{
    public class DepositarValidator : AbstractValidator<AccountModel>
    {
        public DepositarValidator()
        {
            RuleFor(c => c.Id)
               .Must(c => c != null)
               .WithMessage("Id necessário");

            RuleFor(c => c.Valor)
               .GreaterThan(0)
               .WithMessage("Valor necessário");
        }
    }
}
