using FluentValidation;
using FuncionalTest.Api.ViewModels;

namespace FuncionalTest.Api.Validations
{
    public class VerificarSaldoValidator : AbstractValidator<AccountModel>
    {
        public VerificarSaldoValidator()
        {
            RuleFor(c => c.Id)
                .Must(c => c != null)
                .WithMessage("Id necessário");
        }
    }
}
