using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Notifications;

namespace FuncionalTest.Domain.Interfaces.IServices
{
    public interface IAccountService
    {
        Notification Sacar(AccountCommand command);
        Notification Depositar(AccountCommand command);
        Notification VerificarSaldo(VerificarSaldoCommand command);
        Notification CriarConta();

    }
}
