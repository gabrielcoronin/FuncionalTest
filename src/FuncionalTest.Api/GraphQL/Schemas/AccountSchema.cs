using FuncionalTest.Api.GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FuncionalTest.Api.GraphQL.Schemas
{
    public class AccountSchema : Schema
    {
        public AccountSchema(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AccountQuery>();
        }
    }
}