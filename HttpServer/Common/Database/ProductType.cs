using System;
using System.Collections.Generic;

namespace HttpServer.Common.Database
{
    public partial class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte FeatureId { get; set; }

        public virtual ProductFeature Feature { get; set; }
    }
}
