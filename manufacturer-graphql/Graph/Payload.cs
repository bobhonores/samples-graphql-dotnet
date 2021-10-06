using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manufacturer_graphql.Data;

namespace manufacturer_graphql.Graph
{
    public class AddManufacturerPayload
    {
        public Manufacturer Manufacturer { get; }

        public AddManufacturerPayload(Manufacturer manufacturer)
        {
            Manufacturer = manufacturer;
        }
    }

    public class AddProductPayload
    {
        public Product Product { get; }

        public AddProductPayload(Product product)
        {
            Product = product;
        }
    }
}