using FuncionalTest.Domain.REST.Models;
using GraphQL.Types;

namespace FuncionalTest.Api.GraphQL.Types
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Name = "Account";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id da conta");
            Field(x => x.Saldo).Description("Saldo da conta");
        }
    }
}
