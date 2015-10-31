using System;
using System.IO;
using System.Linq;
using Marketing;
using Newtonsoft.Json;
using Sales;
using Warehouse;

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

            var inventory = books.Select(x =>
            {
                var stock = _random.NextDouble() < 0.3 ? 0 : _random.Next(100);

                return new Inventory { BookId = x.Id, Stock = stock, NextExpectedDelivery = stock == 0 ? DateTime.Now + TimeSpan.FromDays(_random.Next(30)) : (DateTime?)null };
            });

            File.WriteAllText("inventory.json", JsonConvert.SerializeObject(inventory, Formatting.Indented));
        }
    }
}
