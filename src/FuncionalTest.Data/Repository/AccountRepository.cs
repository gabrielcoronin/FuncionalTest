using FuncionalTest.Data.Context;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionalTest.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MeuDbContext _dbContext;
        public AccountRepository(MeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account BuscarConta(Account account)
        {
            var conta = (from _a in _dbContext.Accounts.AsNoTracking()
                         where _a.Id == account.Id
                         select _a).SingleOrDefault();

            return conta;
        }

        public async Task<Account> CriarConta(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> Depositar(Account account)
        {
            _dbContext.Attach(account).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> Sacar(Account account)
        {
            _dbContext.Attach(account).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return account;
        }
    }
}
