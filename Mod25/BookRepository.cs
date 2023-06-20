using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod25
{
    public class BookRepository
    {
        public void GetBookForDate(AppContext db)
        {

            // Получать список книг определенного жанра и вышедших между определенными годами.
            var query = db.Books
         .Where(b => b.Year  >= 2013 && b.Year <= 2020)  
         .ToList();
           foreach (var item in query)
            {
                Console.WriteLine($"Название книги : {item.Title} Год выпуска:  {item.Year}"  );
            }
        }

        public void GetBookForAuthor(AppContext db)
        {
            //Получать количество книг определенного автора в библиотеке.
            var query = db.Books
         .Where(b => b.Author  == "Я")  
         .ToList();
            foreach (var item in query)
            {
                Console.WriteLine($"Название книги : {item.Title} Автор:  {item.Author}");
            }
        }

        
        public void GetBookCountForGenre(AppContext db)
        {
            //Получать количество книг определенного жанра в библиотеке.
            var query = db.Books
         .Where(b => b.Genre == "Фантастика")
         .ToList();
            Console.WriteLine($"В жанре фантастика кол-во книг = {query.Count()}") ;
           
        }
        public void GetBookSortYear(AppContext db)
        {
            
            var query = db.Books.OrderByDescending(b => b.Year)
         .ToList();
            foreach (var item in query)
            {
                Console.WriteLine($"Название книги : {item.Title} Год выпуска:  {item.Year}");
            }

        }
        public void GetBookSortTitle(AppContext db)
        {

            var query = db.Books.OrderBy(b => b.Title)
         .ToList();
            foreach (var item in query)
            {
                Console.WriteLine($"Название книги : {item.Title} Год выпуска:  {item.Year}");
            }

        }

        public void GetBookMaxYear(AppContext db)
        {
            var query = db.Books.OrderByDescending(b => b.Year).First();

            Console.WriteLine($"Название книги : {query.Title} Год выпуска:  {query.Year}");

        }
        public void GetBookForUser(AppContext db)
        {
            //Получать количество книг на руках у пользователя.
            Console.WriteLine("Введите ID пользователя для получения книг");
            var id = Console.ReadLine();
            var UserID = db.Books.Where(b => b.UserId == int.Parse(id)).ToList();
            Console.WriteLine($"У пользователя с ID = {id}, книг на руках в кол-ве = {UserID.Count}");
        }

        public void GetBookHasValueTitle(AppContext db)
        {
            //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.

            var bookflag = db.Books.Any(b => b.Title == "Мы из будущего" && b.Author == "Володя Пупкин");

            Console.WriteLine($"Книга с таким автором и названием имеет {bookflag}");
        }

        public void GetBookHasValueUser(AppContext db)
        {
            //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
            Console.WriteLine("Введите ID пользователя для получения информации по книге Мы из будущего ");
            var id = Console.ReadLine();
            var bookflag = db.Books.Any(b => b.Title == "Мы из будущего" && b.UserId == int.Parse(id));

            Console.WriteLine($"Книга с таким пользователем имеет флаг {bookflag}");
        }

    }
}
