using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FuncionalTest.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Task<Account> Depositar(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Sacar(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> VerificarSaldo(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
