using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manufacturer_graphql.Graph
{
    public record AddManufacturerInput(string Name);
    public record AddProductInput(string Name, float Price, DateTime LastUpdated, int ManufacturerId);
}