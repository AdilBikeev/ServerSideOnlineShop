using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerSideOnlineShop;
using HttpServer.Common.Loggers;
using HttpServer.Common;

namespace ServerSideOnlineShop.Models.IdentModels
{
    public class IdentModel : BaseModel, IIdentService
    {
        public IdentModel()
        {
            this.Name = "Ident";
            this.shopDb.User.Load();
            this.logger = new Logger(this.Name);
        }

        /// <summary>
        /// Проверяет - есть ли пользователь с указанным login и password в БД
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        public bool Auth(string login, string password)
        {
            this.logger.Log($"Authorization Request: login={login}, password={password}");

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;
            var res = shopDb.User.Local.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (res == null)
                return false;
            else
                return true;
        }
    }
}
