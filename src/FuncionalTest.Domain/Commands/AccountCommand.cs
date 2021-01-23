using FuncionalTest.Domain.Models;
using System;

namespace FuncionalTest.Domain.Commands
{
    public class AccountCommand
    {
        public AccountCommand(Guid id, double valor)
        {
            Account = new Account { Id = id };
            Valor = valor;
        }

        public Account Account { get; set; }
        public double Valor { get; set; }
    }
}
