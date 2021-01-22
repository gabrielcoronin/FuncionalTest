using FluentValidation;
using FuncionalTest.Domain.REST.Commands;

namespace FuncionalTest.Api.Validations
{
    public class VerificarSaldoValidator : AbstractValidator<VerificarSaldoCommand>
    {
        public VerificarSaldoValidator()
        {
            RuleFor(c => c.Account.Id)
                .Must(c => c != null)
                .WithMessage("Id necessário");
        }
    }
}
