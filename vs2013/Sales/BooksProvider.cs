using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Sales
{
    public class BooksProvider
    {
        private static Book[] _books;

        private static IEnumerable<Book> Books
        {
            get
            {
                return _books ?? (_books = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText("books.json")));
            }
        }

        public IEnumerable<Book> AllBooks()
        {
            return Books;
        }

        public Book FindById(string id)
        {
            return Books.FirstOrDefault(x => x.Id == id);
        }
    }
}