using System;
// using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Sample.ToDoList.GraphQL.Data;
using Sample.ToDoList.GraphQL.Models;

namespace Sample.ToDoList.GraphQL.GraphQL.Types
{
    public class ItemType : ObjectType<Item>
    {
        // protected override void Configure(IObjectTypeDescriptor<Item> descriptor)
        // {
        //     descriptor.Description("Used to define todo item for a specific list");

        //     descriptor.Field(x => x.List)
        //               .ResolveWith<Resolvers>(p => p.GetList(default!, default!))
        //               .UseDbContext<ApplicationContext>()
        //               .Description("This is the list that the item belongs to");
        // }

        // private class Resolvers
        // {
        //     public List GetList(Item item, [ScopedService] ApplicationContext context)
        //         => context.Lists.FirstOrDefault(x => x.Id == item.ListId);
        // }
    }
}