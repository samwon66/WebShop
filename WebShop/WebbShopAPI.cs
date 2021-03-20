using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Database;

namespace WebShop
{
    public class WebbShopAPI
    {
        private WSContext context = new WSContext();

        /// <summary>
        /// Metod för inloggning.
        /// Returnera en nolla om användare inte finns.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int LogIn(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user.Id;
            }

            return 0;
        }

        /// <summary>
        /// Metod för utloggning
        /// </summary>
        /// <param name="id"></param>
        public void LogOut(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
    }
}
