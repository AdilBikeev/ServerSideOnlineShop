using System;
using System.Collections.Generic;

namespace HttpServer.Common.Database
{
    public partial class ProductFeature
    {
        public ProductFeature()
        {
            Product = new HashSet<Product>();
            ProductType = new HashSet<ProductType>();
        }

        public byte TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductType> ProductType { get; set; }
    }
}
