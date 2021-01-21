using FuncionalTest.Domain.Models;
using System.Threading.Tasks;

namespace FuncionalTest.Domain.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        Task<Account> Sacar(Account account);
        Task<Account> Depositar(Account account);
        Task<Account> BuscarConta(Account account);
        Task<Account> CriarConta(Account account);
    }
}
