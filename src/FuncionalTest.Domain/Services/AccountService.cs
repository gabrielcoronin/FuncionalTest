using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Models;
using System.Threading.Tasks;

namespace FuncionalTest.Domain.Services
{
    public class AccountService : IAccountService
    {
        public async Task<Account> Depositar(DepositarCommand command)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Account> Sacar(SacarCommand command)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Account> VerificarSaldo(VerificarSaldoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
