﻿using System;
using System.Collections.Generic;

namespace HttpServer.Common.Database
{
    public partial class User
    {
        public User()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
