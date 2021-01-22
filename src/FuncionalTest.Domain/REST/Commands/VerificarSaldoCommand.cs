using FuncionalTest.Domain.REST.Models;
using System;

namespace FuncionalTest.Domain.REST.Commands
{
    public class VerificarSaldoCommand
    {
        public VerificarSaldoCommand(Guid id)
        {
            Account = new Account { Id = id };
        }

        public Account Account { get; set; }
    }
}
