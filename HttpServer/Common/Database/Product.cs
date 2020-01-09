using System;
using System.Collections.Generic;

namespace HttpServer.Common.Database
{
    public partial class Product
    {
        public int Id { get; set; }
        public int SallerId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public DateTime DatePublication { get; set; }

        public virtual User Saller { get; set; }
        public virtual ProductStatus StatusNavigation { get; set; }
        public virtual ProductFeature TypeNavigation { get; set; }
        public virtual ProductFeatureSelect ProductFeatureSelect { get; set; }
    }
}
