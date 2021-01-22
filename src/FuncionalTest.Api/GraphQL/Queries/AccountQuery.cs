using FuncionalTest.Api.GraphQL.Types;
using FuncionalTest.Data.GraphQL.Repositories;
using FuncionalTest.Domain.REST.Models;
using GraphQL.Types;
using System;

namespace FuncionalTest.Api.GraphQL.Queries
{
    public class AccountQuery : ObjectGraphType<object>
    {
        public AccountQuery(Repository repositorio)
        {
            Field<ListGraphType<AccountType>>("account",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="id"},
                    new QueryArgument<StringGraphType>{Name="saldo"}
                }),
                resolve: contexto =>
                {
                    var filtro = new AccountFilter()
                    {
                        Id = contexto.GetArgument<Guid>("id"),
                    };
                    return repositorio.BuscarConta(filtro);
                }

                );
        }
    }
}