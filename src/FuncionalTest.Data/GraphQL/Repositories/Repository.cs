using FuncionalTest.Data.REST.Context;
using FuncionalTest.Domain.REST.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionalTest.Data.GraphQL.Repositories
{
    public class Repository
    {
        private readonly MeuDbContext _context;
        public Repository(MeuDbContext context)
        {
            _context = context;
        }

        public Account BuscarConta(AccountFilter filter)
        {
            var conta = (from _a in _context.Accounts.AsNoTracking()
                         where _a.Id == filter.Id
                         select _a).SingleOrDefault();

            return conta;
        }

        public Account BuscarConta(Guid id)
        {
            var conta = (from _a in _context.Accounts.AsNoTracking()
                         where _a.Id == id
                         select _a).SingleOrDefault();

            return conta;
        }

        public Account CriarConta(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }

        public async Task<Account> Depositar(Account account)
        {
            _context.Attach(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> Sacar(Account account)
        {
            _context.Attach(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }
    }
}

