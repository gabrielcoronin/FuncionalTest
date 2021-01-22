using FuncionalTest.Domain.REST.Commands;
using FuncionalTest.Domain.REST.Notifications;

namespace FuncionalTest.Domain.REST.Interfaces.IServices
{
    public interface IAccountService
    {
        Notification Sacar(AccountCommand command);
        Notification Depositar(AccountCommand command);
        Notification VerificarSaldo(VerificarSaldoCommand command);
        Notification CriarConta();

    }
}
