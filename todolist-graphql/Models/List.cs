using System.Collections.Generic;
using HotChocolate;

namespace Sample.ToDoList.GraphQL.Models
{
    [GraphQLDescription("Used to group the do list item into groups")]
    public class List
    {
        public List()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}