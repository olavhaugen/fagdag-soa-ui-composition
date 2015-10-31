using System;
using System.IO;
using System.Linq;
using Marketing;
using Newtonsoft.Json;

namespace BookGenerator
{
    class Program
    {
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            // https://openlibrary.org/people/tamarind/lists/OL68566L/to-read/export?format=json

            var books = Deserialize.Books("books_raw.json");

            File.WriteAllText("books.json", JsonConvert.SerializeObject(books, Formatting.Indented));

            var prices = books.Select(x => new BookPrice { BookId = x.Id, Price = (decimal)(50 + _random.NextDouble() * 500) });

            File.WriteAllText("book_prices.json", JsonConvert.SerializeObject(prices, Formatting.Indented));
        }
    }
}
