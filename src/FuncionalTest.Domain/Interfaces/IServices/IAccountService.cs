using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Notifications;

namespace FuncionalTest.Domain.Interfaces.IServices
{
    public interface IAccountService
    {
        Notification Sacar(SacarCommand command);
        Notification Depositar(DepositarCommand command);
        Notification VerificarSaldo(VerificarSaldoCommand command);
        Notification CriarConta();

    }
}
