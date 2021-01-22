using FuncionalTest.Domain.REST.Commands;
using FuncionalTest.Domain.REST.Interfaces.IRepositories;
using FuncionalTest.Domain.REST.Interfaces.IServices;
using FuncionalTest.Domain.REST.Models;
using FuncionalTest.Domain.REST.Notifications;

namespace FuncionalTest.Domain.REST.Services
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
            var account = new Account
            {
                Saldo = 100
            };

            var entity = _accountRepository.CriarConta(account);

            return Notification.CreateSuccess(null, null, 200,
                $"Conta -> { entity.Id}\n" +
                $"Saldo atual -> {entity.Saldo}");
        }

        public Notification Depositar(AccountCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            if (command.Account.Id == null || conta.Id == null)
                return Notification.CreateError(message: "Conta inválida");

            conta.Saldo += command.Valor;
            command.Account.Saldo = conta.Saldo;

            var entity = _accountRepository.Depositar(command.Account);

            return Notification.CreateSuccess(null, null, 200,
                $"Conta -> { command.Account.Id}\n" +
                $"Valor depositado -> {command.Valor}\n" +
                $"Saldo atual -> {conta.Saldo}");
        }

        public Notification Sacar(AccountCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            if (command.Account.Id == null || conta.Id == null) 
                return Notification.CreateError(message: "Conta inválida");

            if (conta.Saldo < command.Valor || conta.Saldo <= 0)
                return Notification.CreateError(message: "O valor que você deseja sacar ultrapassar o limite de saldo da conta, tente outro valor.");

            conta.Saldo -= command.Valor;
            command.Account.Saldo = conta.Saldo;

            var entity = _accountRepository.Sacar(command.Account);

            return Notification.CreateSuccess(null, null, 200,
                $"Conta -> { command.Account.Id}\n" +
                $"Valor sacado -> {command.Valor}\n" + 
                $"Saldo atual -> {conta.Saldo}");
        }

        public Notification VerificarSaldo(VerificarSaldoCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            if (command.Account.Id == null || conta.Id == null)
                return Notification.CreateError(message: "Conta inválida");

            return Notification.CreateSuccess(null, null, 200,
                $"Conta -> { command.Account.Id}\n" +
                $"Saldo atual -> {conta.Saldo}");
        }
    }
}
