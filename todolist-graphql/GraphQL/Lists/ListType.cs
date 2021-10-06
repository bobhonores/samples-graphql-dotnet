using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Sample.ToDoList.GraphQL.Data;
using Sample.ToDoList.GraphQL.Models;

namespace Sample.ToDoList.GraphQL.GraphQL.Lists
{
    public class ListType : ObjectType<List>
    {
        // protected override void Configure(IObjectTypeDescriptor<List> descriptor)
        // {
        //     descriptor.Description("Used to group the do list item into groups");

        //     descriptor.Field(x => x.Items).Ignore();

        //     descriptor.Field(x => x.Items)
        //                 .ResolveWith<Resolvers>(p => p.GetItems(default!, default!))
        //                 .UseDbContext<ApplicationContext>()
        //                 .Description("This is the list of to do item available for this list");
        // }

        // private class Resolvers
        // {
        //     public IQueryable<Item> GetItems(List list, [ScopedService] ApplicationContext context)
        //         => context.Items.Where(x => x.ListId == list.Id);
        // }
    }
}