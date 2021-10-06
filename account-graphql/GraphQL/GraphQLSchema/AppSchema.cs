using System;
using Sample.IdentityManagement.GraphQL.GraphQL.GraphQLQueries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.IdentityManagement.GraphQL.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}