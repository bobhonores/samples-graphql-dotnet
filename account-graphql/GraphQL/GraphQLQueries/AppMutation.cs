using System;
using Sample.IdentityManagement.GraphQL.Contracts;
using Sample.IdentityManagement.GraphQL.Entities;
using Sample.IdentityManagement.GraphQL.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace Sample.IdentityManagement.GraphQL.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository, IHttpContextAccessor accessor)
        {
            FieldAsync<OwnerType>("createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: async context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return await repository.CreateOwner(owner, accessor.HttpContext.RequestAborted);
                });

            FieldAsync<OwnerType>("updateOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }
                ),
                resolve: async context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var dbOwner = await repository.GetById(ownerId, accessor.HttpContext.RequestAborted);

                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }

                    return await repository.UpdateOwner(dbOwner, owner, accessor.HttpContext.RequestAborted);
                });

            FieldAsync<StringGraphType>("deleteOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: async context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var owner = await repository.GetById(ownerId, accessor.HttpContext.RequestAborted);

                    if (owner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }

                    await repository.DeleteOwner(owner, accessor.HttpContext.RequestAborted);
                    return $"The owner with the id: {ownerId} has been successfully deleted from db.";
                });
        }
    }
}