using FuncionalTest.Domain.Models;
using System.Threading.Tasks;

namespace FuncionalTest.Domain.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        Task<Account> Sacar(Account account);
        Task<Account> Depositar(Account account);
        Account BuscarConta(Account account);
        Account CriarConta(Account account);
    }
}
