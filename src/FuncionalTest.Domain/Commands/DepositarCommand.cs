using FuncionalTest.Domain.Models;

namespace FuncionalTest.Domain.Commands
{
    public class DepositarCommand
    {
        public Account Account { get; set; }
        public double Valor { get; set; }
    }
}
