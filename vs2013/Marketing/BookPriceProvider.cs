using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Marketing
{
    public class BookPriceProvider
    {
        private static BookPrice[] _bookPrices;

        private static IEnumerable<BookPrice> BookPrices
        {
            get
            {
                return _bookPrices ?? (_bookPrices = JsonConvert.DeserializeObject<BookPrice[]>(File.ReadAllText("book_prices.json")));
            }
        }

        public BookPrice FindById(string id)
        {
            return BookPrices.FirstOrDefault(x => x.BookId == id);
        }
    }
}