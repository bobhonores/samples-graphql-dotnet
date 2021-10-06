using HotChocolate;

namespace Sample.ToDoList.GraphQL.Models
{
    [GraphQLDescription("Used to define todo item for a specific list")]
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [GraphQLDescription("If the user has completed this item")]
        public bool Done { get; set; }
        [GraphQLDescription("The list which this item belongs to")]
        public int ListId { get; set; }
        public virtual List List { get; set; }
    }
}