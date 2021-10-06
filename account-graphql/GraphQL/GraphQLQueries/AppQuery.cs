using System;
using Sample.IdentityManagement.GraphQL.Contracts;
using Sample.IdentityManagement.GraphQL.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace Sample.IdentityManagement.GraphQL.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository, IHttpContextAccessor accessor)
        {
            FieldAsync<ListGraphType<OwnerType>>("owners",
                resolve: async context => await repository.GetAll(accessor.HttpContext.RequestAborted));

            FieldAsync<OwnerType>("owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: async context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid"));
                        return null;
                    }

                    return await repository.GetById(id, accessor.HttpContext.RequestAborted);
                });
        }
    }
}