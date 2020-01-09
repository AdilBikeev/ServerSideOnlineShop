using System;
using System.Collections.Generic;

namespace HttpServer.Common.Database
{
    public partial class ProductStatus
    {
        public ProductStatus()
        {
            Product = new HashSet<Product>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
