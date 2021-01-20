using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalTest.Domain.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<Account> Sacar(SacarCommand command);
        Task<Account> Depositar(DepositarCommand command);
        Task<Account> VerificarSaldo(VerificarSaldoCommand command);
    }
}
