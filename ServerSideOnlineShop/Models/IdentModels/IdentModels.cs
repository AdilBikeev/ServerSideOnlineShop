using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerSideOnlineShop;

namespace ServerSideOnlineShop.Models.IdentModels
{
    public class IdentModels : BaseModel, IIdentService
    {
        public IdentModels()
        {
            this.Name = "Ident";
            this.shopDb.User.Load();
        }

        /// <summary>
        /// Проверяет - есть ли пользователь с указанным login и password в БД
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        public bool Auth(string login, string password)
        {
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
