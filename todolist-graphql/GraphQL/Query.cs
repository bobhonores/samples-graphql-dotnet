using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Sample.ToDoList.GraphQL.Data;
using Sample.ToDoList.GraphQL.Models;

namespace Sample.ToDoList.GraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationContext))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Item> GetItems([ScopedService] ApplicationContext context) => context.Items;

        [UseDbContext(typeof(ApplicationContext))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<List> GetLists([ScopedService] ApplicationContext context) => context.Lists;
    }
}