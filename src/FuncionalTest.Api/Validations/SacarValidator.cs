using FluentValidation;
using FuncionalTest.Api.ViewModels;

namespace FuncionalTest.Api.Validations
{
    public class SacarValidator : AbstractValidator<AccountModel>
    {
        public SacarValidator()
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
