using FuncionalTest.Api.GraphQL.Types;
using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IServices;
using GraphQL;
using GraphQL.Types;
using System;

namespace FuncionalTest.Api.GraphQL.Queries
{
    public class AccountQuery : ObjectGraphType
    {

        public AccountQuery(IAccountService service)
        {

            //verificar saldo
            Field<AccountType>(                
                name: "saldo",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="id"},
                }),
                resolve: contexto =>
                {
                    var idString = contexto.GetArgument<string>("id");
                    var id = Guid.Parse(idString);
                    var command = new VerificarSaldoCommand(id);

                    return service.VerificarSaldo(command);
                });
    
            //criarconta
            Field<AccountType>(
                name: "criarConta",
                resolve: context =>
                {
                    return service.CriarConta();
                });

            //sacar
            Field<AccountType>(
                name: "sacar",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "contaId" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "valor" }
                ),
                resolve: context =>
                {
                    var idString = context.GetArgument<string>("contaId");
                    var valor = context.GetArgument<double>("valor");
                    var id = Guid.Parse(idString);
                    var command = new AccountCommand(id,valor);

                    var conta = service.Sacar(command);

                    if (conta == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar conta na base de dados."));
                        return null;
                    }
                    return conta;
                });

            //depositar
            Field<AccountType>(
              name: "depositar",
              arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "contaId" },
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "valor" }
              ),
              resolve: context =>
              {
                  var idString = context.GetArgument<string>("contaId");
                  var valor = context.GetArgument<double>("valor");
                  var id = Guid.Parse(idString);

                  var command = new AccountCommand(id, valor);

                  var conta = service.Depositar(command);

                  if (conta == null)
                  {
                      context.Errors.Add(new ExecutionError("Não foi possivel encontrar conta na base de dados."));
                      return null;
                  }
                  return conta;
              });
        }
    }
}