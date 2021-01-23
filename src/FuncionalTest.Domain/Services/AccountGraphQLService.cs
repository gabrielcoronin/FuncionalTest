using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Models;
using FuncionalTest.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace FuncionalTest.Domain.Services
{
    public class AccountGraphQLService : IAccountGraphQLService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountGraphQLService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> CriarConta()
        {
            var account = new Account
            {
                Saldo = 100
            };

            return await _accountRepository.CriarConta(account);
        }

        public async Task<Account> Depositar(AccountCommand command)
        {
            var conta = _accountRepository.BuscarConta(command.Account);

            conta.Saldo += command.Valor;
            command.Account.Saldo = conta.Saldo;

            return await  _accountRepository.Depositar(command.Account);
        }

        public async Task<Account> Sacar(AccountCommand command)
        {       
            var conta = _accountRepository.BuscarConta(command.Account);       

            conta.Saldo -= command.Valor;
            command.Account.Saldo = conta.Saldo;

            return await _accountRepository.Sacar(command.Account);            
        }

        public Account VerificarSaldo(VerificarSaldoCommand command)
        {
            return _accountRepository.BuscarConta(command.Account);
        }
    }
}
