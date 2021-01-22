using FuncionalTest.Domain.REST.Models;
using GraphQL.Types;

namespace FuncionalTest.Api.GraphQL.Types
{
    public class AccountInputType : InputObjectGraphType<Account>
    {
        public AccountInputType()
        {
            Name = "AccountInput";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id da conta");
            Field(x => x.Saldo).Description("Saldo da conta");           
        }
    }
}
