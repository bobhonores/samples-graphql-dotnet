using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using manufacturer_graphql.Data;

namespace manufacturer_graphql.Graph
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service] ApplicationDbContext context) =>
            context.Products;
    }
}