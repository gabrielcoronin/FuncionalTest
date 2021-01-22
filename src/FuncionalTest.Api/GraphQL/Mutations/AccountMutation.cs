using FuncionalTest.Api.GraphQL.Types;
using FuncionalTest.Data.GraphQL.Repositories;
using FuncionalTest.Domain.REST.Models;
using GraphQL;
using GraphQL.Types;
using System;

namespace FuncionalTest.Api.GraphQL.Mutations
{
    public class AccountMutation : ObjectGraphType<object>
    {
        //sacar -> Guid contaId, double valor
        //depositar ->  Guid contaId, double valor
        public AccountMutation(Repository repositorio)
        {
            Name = "Mutation";

            //criarconta
            Field<AccountType>("criarConta",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "account" }
                ),
                resolve: context =>
                {
                    var account = context.GetArgument<Account>("account");
                    var conta = new Account { Id = Guid.NewGuid(), Saldo = 100 };
                    return repositorio.CriarConta(conta);
                });


            //saldo -> Guid contaId
            Field<AccountType>("consultarSaldo",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "contaId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("contaId");

                    var dbAccount = repositorio.BuscarConta(id);
                    if (dbAccount == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    return dbAccount.Saldo;
                });


            Field<StringGraphType>("sacar",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "contaId" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "valor" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("contaId");
                    var valor = context.GetArgument<double>("valor");

                    var conta = repositorio.BuscarConta(id);
                    conta.Saldo -= valor;

                    var dbUsuario = repositorio.Sacar(conta);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar conta na base de dados."));
                        return null;
                    }
                    return conta;                    
                });

            Field<StringGraphType>("depositar",
              arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "contaId" },
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "valor" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<Guid>("contaId");
                  var valor = context.GetArgument<double>("valor");

                  var conta = repositorio.BuscarConta(id);
                  conta.Saldo += valor;

                  var dbUsuario = repositorio.Depositar(conta);
                  if (dbUsuario == null)
                  {
                      context.Errors.Add(new ExecutionError("Não foi possivel encontrar conta na base de dados."));
                      return null;
                  }
                  return conta;
              });
        }
    }
}