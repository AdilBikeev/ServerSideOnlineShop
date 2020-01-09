using System;
using System.Collections.Generic;

namespace HttpServer.Common.Database
{
    public partial class ProductFeatureSelect
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Params { get; set; }

        public virtual Product Product { get; set; }
    }
}
