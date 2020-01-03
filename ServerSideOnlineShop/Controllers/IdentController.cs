using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json.Linq;
using ServerSideOnlineShop.Common.Hellpers;
using ServerSideOnlineShop.Models.IdentModels;

namespace ServerSideOnlineShop.Controllers
{
    public class IdentController : Controller
    {
        private IdentModels ident;
        public IdentController()
        {
            ident = new IdentModels();
        }

        [Route("/ident/autorisation")]
        [HttpPost]
        public JObject Autorisation([FromBody] JObject data)
        {
            if (data != null && 
                    ident.Auth(JsonHellper.GetValue(data, "login"), JsonHellper.GetValue(data, "password"))
                )
                return JsonHellper.GetOkReesult();
            else
                return JsonHellper.GetBadReesult();
        }
    }
}
