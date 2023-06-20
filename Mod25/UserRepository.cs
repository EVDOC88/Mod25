using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Mod25
{
    public class UserRepository
    {

        public void FindById(AppContext db)
        {
            Console.WriteLine("Введите ID пользователя для поиска");
            var ID = Console.ReadLine();
            // Выбор пользователя по ID
            var IdUser = db.Users.FirstOrDefault(u => u.Id == int.Parse(ID));
                Console.WriteLine(IdUser.Name);
        }
        public void FindAllUser(AppContext db)
        {

            // Выбор всех пользователей
            var allUsersd = db.Users.ToList();
            foreach (var user in allUsersd)
            {
                Console.WriteLine(user.Name);
            }
        }
        public void AddUser(AppContext db)
        {              // Добавление одиночного пользователя
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            Console.WriteLine("Ввведите почту пользователя");
            var email = Console.ReadLine();
            var user = new User { Name = name, Email = email };
            db.Users.Add(user);
            db.SaveChanges(); 
            
        }
        public void RemoveUser(AppContext db)
        {              // Удаление одиночного пользователя
            Console.WriteLine("Введите ID пользователя для удаления");
            var id = Console.ReadLine();
            var UserID = db.Users.FirstOrDefault(u=>u.Id == int.Parse(id));
            db.Users.Remove(UserID);
            db.SaveChanges();

        }
        public void UpdateUserById(AppContext db)
        {              // Обновление одиночного пользователя
            Console.WriteLine("Введите ID пользователя для обновления имени");
            var id = Console.ReadLine();
            var UserID = db.Users.FirstOrDefault(u => u.Id == int.Parse(id));
            Console.WriteLine("Введите новое имя");
            var name = Console.ReadLine();
            UserID.Name = name;
            db.SaveChanges();

        }

    }
}
