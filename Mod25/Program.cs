

namespace Mod25
{
    internal class Program
    {
        public static UserRepository userRepository;
        public static BookRepository bookRepository;

        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "User1", Email = "User1@mail.ru" };
                var user2 = new User { Name = "User2", Email = "User2@mail.ru" };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                var book1 = new Book { Title = "Мы из будущего", Year = 2011, Author = "Володя Пупкин", Genre ="Фантастика" };
                var book2 = new Book { Title = "Тарзан", Year = 2019, Author = "Том Соер", Genre = "Приключение" };
                book1.UserId = user1.Id;
                db.Books.Add(book1);
                db.Books.Add(book2);

                db.SaveChanges();

                userRepository = new UserRepository();
                bookRepository = new BookRepository();



                while (true)
                {

                    Console.WriteLine("\nНайти пользователя по ID (нажмите 1)");
                    Console.WriteLine("Найти всех пользователей (нажмите 2)");
                    Console.WriteLine("Добавить пользователя (нажмите 3)");
                    Console.WriteLine("Удалить пользователя по ID  (нажмите 4)");
                    Console.WriteLine("Обновить имя пользователя по ID (нажмите 5)");
                    Console.WriteLine("Получить список книг между 2013 и 2020 годами (нажмите 6)");
                    Console.WriteLine("Все книги автора по автором Я (нажмите 8)");
                    Console.WriteLine("Количество книг в жанре Фантастика (нажмите 9)");
                    Console.WriteLine("Все книги отсортированные в порядке убывания года их выхода  (нажмите 10)");
                    Console.WriteLine("Все книги отсортированные в алфавитном порядке по названию.  (нажмите 11)");
                    Console.WriteLine("Получение последней вышедшей книги.  (нажмите 12)");
                    Console.WriteLine("Кол-во книг у пользователя на руках.  (нажмите 13)");
                    Console.WriteLine("Булевый флаг с названием книги Мы из будущего и автором Володя Пупкин  (нажмите 14)");
                    Console.WriteLine("Булевый флаг  булевый флаг о том, есть ли определенная книга Мы из будущего на руках у пользователя.  (нажмите 15)");
                    Console.WriteLine("Выйти из профиля (нажмите 7)");

                    string keyValue = Console.ReadLine();

                    if (keyValue == "7") break;

                    switch (keyValue)
                    {
                        case "1":
                            {
                                userRepository.FindById(db);
                                break;
                            }
                        case "2":
                            {
                                userRepository.FindAllUser(db);
                                break;
                            }
                        case "3":
                            {
                                userRepository.AddUser(db);
                                break;
                            }
                        case "4":
                            {
                                userRepository.RemoveUser(db);
                                break;
                            }
                        case "5":
                            {
                                userRepository.UpdateUserById(db);
                                break;
                            }
                        case "6":
                            {
                                bookRepository.GetBookForDate(db);
                                break;
                            }
                        case "8":
                            {
                                bookRepository.GetBookForAuthor(db);
                                break;
                            }
                        case "9":
                            {
                                bookRepository.GetBookCountForGenre(db);
                                break;
                            }
                        case "10":
                            {
                                bookRepository.GetBookSortYear(db);
                                break;
                            }
                        case "11":
                            {
                                bookRepository.GetBookSortTitle(db);
                                break;
                            }
                        case "12":
                            {
                                bookRepository.GetBookMaxYear(db);
                                break;
                            }
                        case "13":
                            {
                                bookRepository.GetBookForUser(db);
                                break;
                            }
                        case "14":
                            {
                                bookRepository.GetBookHasValueTitle(db);
                                break;
                            }
                        case "15":
                            {
                                bookRepository.GetBookHasValueUser(db);
                                break;
                            }
                    }







                }
            }
        }
    }
}