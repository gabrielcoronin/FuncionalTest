using FuncionalTest.Domain.Models;
using System;

namespace FuncionalTest.Domain.Commands
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
