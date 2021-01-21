using FuncionalTest.Data.Context;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Account> BuscarConta(Account account)
        {
            return await _dbContext.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == account.Id);
        }

        public async Task<Account> CriarConta(Account account)
        {
            _dbContext.Accounts.Add(account);
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
