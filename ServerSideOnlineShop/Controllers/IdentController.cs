using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json.Linq;

namespace ServerSideOnlineShop.Controllers
{
    public class IdentController: Controller
    {
        [Route("/ident/autorisation")]
        public JsonResult Autorisation (string login, string password)
        {
            JObject obj = new JObject();
            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {

            }

            JsonResult response = new JsonResult(obj);
            return response;
        }
    }
}
