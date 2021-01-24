using FuncionalTest.Domain.Exceptions;
using System;

namespace FuncionalTest.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public double Saldo { get; set; }

        public AccountException Message { get; set; }

    }
}
