using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Models;
using FuncionalTest.Domain.Notifications;
using System;

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
            var account = new Account
            {
                Id = Guid.NewGuid(),
                Saldo = 100
            };

            var entity = _accountRepository.CriarConta(account);
            return Notification.CreateSuccess(entity, null, 201, "Conta criada com sucesso!");
        }

        public Notification Depositar(DepositarCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            command.Valor += conta.Result.Saldo;
            command.Account.Saldo = conta.Result.Saldo;

            var entity = _accountRepository.Depositar(command.Account);

            return Notification.CreateSuccess(entity, null, 200, "Deposito efetuado com sucesso!");
        }

        public Notification Sacar(SacarCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            if (conta.Result.Saldo < command.Valor)
                return Notification.CreateError(message: "O valor que você deseja sacar ultrapassar o limite de saldo da conta, tente outro valor.");

            command.Valor -= conta.Result.Saldo;
            command.Account.Saldo = conta.Result.Saldo;

            var entity = _accountRepository.Sacar(command.Account);

            return Notification.CreateSuccess(entity, null, 200, "Valor sacado com sucesso!");
        }

        public Notification VerificarSaldo(VerificarSaldoCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            return Notification.CreateSuccess(null, null, 200, $"Saldo atual: {conta.Result.Saldo}");
        }
    }
}
