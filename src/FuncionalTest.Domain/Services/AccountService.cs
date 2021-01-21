using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Notifications;

namespace FuncionalTest.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Notification CriarConta()
        {
            var entity = _accountRepository.CriarConta();
            return Notification.CreateSuccess(entity, null, 201, "Conta criada com sucesso!");
        }

        public Notification Depositar(DepositarCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);



            var entity = _accountRepository.Depositar(command.Account);


            return Notification.CreateSuccess(entity, null, 201, "Deposito efetuado com sucesso!");
        }

        public Notification Sacar(SacarCommand command)
        {
            var entity = _accountRepository.Sacar(command.Account);
            return Notification.CreateSuccess(entity, null, 201, "Valor sacado com sucesso!");
        }

        public Notification VerificarSaldo(VerificarSaldoCommand command)
        {
            var entity = _accountRepository.VerificarSaldo(command.Account);
            return Notification.CreateSuccess(entity, null, 201, $"Saldo atual: {entity.saldo}");
        }
    }
}
