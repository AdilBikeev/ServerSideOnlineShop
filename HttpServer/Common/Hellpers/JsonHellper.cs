using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ServerSideOnlineShop.Common.Hellpers
{
    public static class JsonHellper
    {
        public static JObject GetOkReesult() =>  new JObject(){ { "status", "OK" } };
        public static JObject GetBadReesult() => new JObject() { 
                                                                   { "status", "error" } ,
                                                                    { "err_desc", "Ошибка при выполнении запроса на стороне сервера" }
                                                                };
    }
}
