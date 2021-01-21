using FuncionalTest.Domain.Models;

namespace FuncionalTest.Domain.Commands
{
    public class SacarCommand
    {
        public Account Account { get; set; }
        public double Valor { get; set; }
    }
}
