using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Exceptions;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Models;
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

            if (command.Account.Id == null || conta.Id == null)
                throw new AccountException("Conta inválida");

            conta.Saldo += command.Valor;
            command.Account.Saldo = conta.Saldo;

            return await  _accountRepository.Depositar(command.Account);
        }

        public async Task<Account> Sacar(AccountCommand command)
        {       
            var conta = _accountRepository.BuscarConta(command.Account);

            if (command.Account.Id == null || conta.Id == null)
                throw new AccountException("Conta inválida");

            if (conta.Saldo < command.Valor || conta.Saldo <= 0)
                throw new AccountException("O valor que você deseja sacar ultrapassar o limite de saldo da conta, tente outro valor.");

            conta.Saldo -= command.Valor;
            command.Account.Saldo = conta.Saldo;

            return await _accountRepository.Sacar(command.Account);            
        }

        public Account VerificarSaldo(VerificarSaldoCommand command)
        {
            if (command.Account.Id == null)
                throw new AccountException("Conta inválida");

            return _accountRepository.BuscarConta(command.Account);
        }
    }
}
