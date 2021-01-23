using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Models;
using System.Threading.Tasks;

namespace FuncionalTest.Domain.Interfaces.IServices
{
    public interface IAccountGraphQLService
    {
        Task<Account> Sacar(AccountCommand command);
        Task<Account> Depositar(AccountCommand command);
        Task<Account> CriarConta();
        Account VerificarSaldo(VerificarSaldoCommand command);

    }
}
