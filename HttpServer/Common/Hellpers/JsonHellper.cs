using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ServerSideOnlineShop.Common.Hellpers
{
    public static class JsonHellper
    {
        public static JObject GetOkReesult() => new JObject() { { "status", "OK" } };
        public static JObject GetBadReesult() => new JObject() {
                                                                   { "status", "error" } ,
                                                                    { "err_desc", "Ошибка при выполнении запроса на стороне сервера" }
                                                                };

        /// <summary>
        /// Возвращает строковое значение свойства JSON объекта
        /// </summary>
        /// <param name="json">JSON объект</param>
        /// <param name="propertyName">Название свойства</param>
        /// <returns></returns>
        public static string GetValue(JObject json, string propertyName) {
            JToken val;
            if (json.TryGetValue(propertyName, StringComparison.OrdinalIgnoreCase, out val))
                return val.Value<string>();
            else
                return string.Empty;
        }
    }
}
