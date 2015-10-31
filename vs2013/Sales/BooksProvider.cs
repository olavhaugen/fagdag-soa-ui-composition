using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Sales
{
    public class BooksProvider
    {
        private static Book[] _books;
        private static BookDetails[] _bookDetails;

        private static IEnumerable<Book> Books
        {
            get
            {
                return _books ?? (_books = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText("books.json")));
            }
        }

        private static IEnumerable<BookDetails> BookDetails
        {
            get
            {
                return _bookDetails ?? (_bookDetails = JsonConvert.DeserializeObject<BookDetails[]>(File.ReadAllText("books.json")));
            }
        }

        public IEnumerable<Book> AllBooks()
        {
            return Books;
        }

        public BookDetails FindById(string id)
        {
            return BookDetails.FirstOrDefault(x => x.Id == id);
        }
    }
}