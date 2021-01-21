using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Notifications;

namespace FuncionalTest.Domain.Services
{
    public class AccountService : IAccountService
    {
        public Notification CriarConta()
        {
            throw new System.NotImplementedException();
        }

        public Notification Depositar(DepositarCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Notification Sacar(SacarCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Notification VerificarSaldo(VerificarSaldoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
