using FuncionalTest.Api.GraphQL.Mutations;
using FuncionalTest.Api.GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FuncionalTest.Api.GraphQL
{
    public class AccountSchema : Schema
    {
        public AccountSchema(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AccountQuery>();
            Mutation = serviceProvider.GetRequiredService<AccountMutation>();

        }
    }
}