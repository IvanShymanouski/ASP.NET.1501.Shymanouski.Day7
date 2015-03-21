using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Books
{
    public class BookListService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        IBookRepository repository;

        public BookListService(IBookRepository repository)
        {
            this.repository = repository;
        }

        public void AddBook(Book book)
        {
            IEnumerable<Book> books = repository.LoadBooks();
            List<Book> newListBooks = new List<Book>();

            foreach (Book existBook in books)
            {
                newListBooks.Add(existBook);
                if (book.Equals(existBook))
                {
                    logger.Error("This book already exist in the repository "+DateTime.Now);
                    throw new ArgumentException("This book already exist in the repository");
                }
            }

            newListBooks.Add(book);
            repository.SaveBooks(newListBooks);
        }


        //отсортировать книги в хранилище по определенному признаку
        public void SortBooks(Comparison<Book> comparer)
        {
            IEnumerable<Book> books = repository.LoadBooks();
            Book[] booksAray = books.ToArray();
            #region control booble sort
            /*for (int i = 0; i < booksAray.Length -1 ; i++)
                for (int j = 0; j < booksAray.Length - 1 - i; j++)
                {
                    if (booksAray[j].CompareTo(booksAray[j + 1]) > 0)
                    {
                        Book temp = booksAray[j + 1];
                        booksAray[j + 1] = booksAray[j];
                        booksAray[j] = temp;
                    }
                }*/
            #endregion
            Array.Sort<Book>(booksAray, comparer);

            books = booksAray.ToList<Book>();

            repository.SaveBooks(books);
        }

        public void RemoveBook(Book book)
        {
            IEnumerable<Book> books = repository.LoadBooks();
            List<Book> newListBooks = new List<Book>();

            bool flag = false;
            foreach (Book existBook in books)
            {
                if (book.Equals(existBook))
                {
                    flag = true;
                }
                else
                {
                    newListBooks.Add(existBook);
                }
            }

            if (flag)
            {
                repository.SaveBooks(newListBooks);
            }
            else
            {
                logger.Error("Book do not exist in the repository " + DateTime.Now);
                throw new ArgumentException("Book do not exist in the repository");
            }
        }

        public IEnumerable<Book> GetRepositoryBooks()
        {
            IEnumerable<Book> books = repository.LoadBooks();
            return books;
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            IEnumerable<Book> books = repository.LoadBooks();
            List<Book> newListBooks = new List<Book>();

            foreach (Book existBook in books)
            {
                if (existBook.Author == author)
                {
                    newListBooks.Add(existBook);
                }
            }

            return newListBooks;
        }
    }
}