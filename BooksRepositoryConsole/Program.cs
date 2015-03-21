using System;
using System.IO;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService books = new BookListService(new BinaryFileRepository(Directory.GetCurrentDirectory() + "\\default.txt"));

            ShowBooks(books);
            Console.WriteLine("-------------");

            #region book Joan Roling
            Book book = new Book()
            {
                Author = "Joan Roling",
                PageCount = 133,
                Price = 10000,
                Title = "King of the kingdom"
            };

            try
            {
                Console.WriteLine("Adding " + book.Author + " " + book.Title);
                books.AddBook(book);
            }
            catch { }
            #endregion

            Console.WriteLine("-------------");

            #region book Jon Skeet
            book = new Book()
            {
                Author = "Jon Skeet",
                PageCount = 614,
                Price = 1500,
                Title = "C# in Depth"
            };

            try
            {
                Console.WriteLine("Adding " + book.Author + " " + book.Title);
                books.AddBook(book);
            }
            catch { }
            #endregion

            Console.WriteLine("-------------");

            #region Jon Skeet
            book = new Book()
            {
                Author = "Jon Skeet",
                PageCount = 644,
                Price = 15044,
                Title = "C# in Depth. Third edition"
            };
            try
            {
                Console.WriteLine("Adding " + book.Author + " " + book.Title);
                books.AddBook(book);
            }
            catch { }
            #endregion

            Console.WriteLine("-------------");

            Console.WriteLine("Jon Skeet books in repositiry:");
            foreach (var bookThatAuthor in books.GetBooksByAuthor("Jon Skeet"))
            {
                Console.WriteLine(bookThatAuthor.Title);
            }

            Console.WriteLine("-------------");

            #region book Jeffrey Richter removing
            book = new Book()
            {
                Author = "Jeffrey Richter",
                PageCount = 896,
                Price = 98762,
                Title = "CLR via C#"
            };

            try
            {
                Console.WriteLine("Removing " + book.Author + " " + book.Title);
                books.RemoveBook(book);
            }
            catch { }
            #endregion

            Console.WriteLine("-------------");

            #region book Jeffrey Richter adding
            book = new Book()
            {
                Author = "Jeffrey Richter",
                PageCount = 896,
                Price = 98762,
                Title = "CLR via C#"
            };

            try
            {
                Console.WriteLine("Adding " + book.Author + " " + book.Title);
                books.AddBook(book);
            }
            catch { }
            #endregion

            Console.WriteLine("-------------");

            #region book Jeffrey Richter adding
            book = new Book()
            {
                Author = "Jeffrey Richter",
                PageCount = 896,
                Price = 98762,
                Title = "CLR via C#"
            };

            try
            {
                Console.WriteLine("Adding " + book.Author + " " + book.Title);
                books.AddBook(book);
            }
            catch { }
            #endregion

            Console.WriteLine("-------------");

            ShowBooks(books);

            Console.WriteLine("\nBooks sorting\n");
            books.SortBooks((x, y) => x.CompareTo(y)*-1);

            ShowBooks(books);

        }

        static void ShowBooks(BookListService books)
        {
            Console.WriteLine("Books in repositiry:");
            foreach (var bookThatAuthor in books.GetRepositoryBooks())
            {

                Console.WriteLine(bookThatAuthor.Author + " " + bookThatAuthor.Title);
            }
        }
    }
}
