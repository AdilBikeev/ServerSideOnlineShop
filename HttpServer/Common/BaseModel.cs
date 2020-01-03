using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServer.Common.Database;

namespace ServerSideOnlineShop.Models
{
    /// <summary>
    /// Базовая модель контроллеров
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Объект для работы с БД
        /// </summary>
        protected ShopOnlineContext shopDb = new ShopOnlineContext();

        /// <summary>
        /// Статус коды для запросов к контроллерам
        /// </summary>
        protected Dictionary<int, string> StatusCode {
            get { 
                return new Dictionary<int, string>()
                {
                    [0] = "Запрос успешно проведен",
                    [30] = "Ошибка на стороне сервера при попытке выполнения запроса"
                };
            } 
        }

        /// <summary>
        /// Название модели
        /// </summary>
        protected string Name { get; set; }
    }
}
