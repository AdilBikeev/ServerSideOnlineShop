using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideOnlineShop.Models.IdentModels
{
    interface IIdentService
    {
        public bool Auth(string login, string password);
    }
}
