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
        private IdentModel ident;
        public IdentController()
        {
            ident = new IdentModel();
        }

        [Route("/ident/autorisation")]
        [HttpPost]
        public JObject Autorisation([FromBody] JObject data)
        {
            JObject res;
            if (data != null && 
                    ident.Auth(JsonHellper.GetValue(data, "login"), JsonHellper.GetValue(data, "password"))
                )
                res = JsonHellper.GetOkReesult();
            else
                res = JsonHellper.GetBadReesult("Неверный логин/пароль");

            this.ident.logger.Log($"Autorisation Response: res={res.ToString()}");

            return res;
        }
    }
}
