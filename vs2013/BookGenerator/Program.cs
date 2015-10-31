using System.IO;
using Newtonsoft.Json;

namespace BookGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://openlibrary.org/people/tamarind/lists/OL68566L/to-read/export?format=json

            var books = Deserialize.Books("books.json");

            File.WriteAllText("sales.json", JsonConvert.SerializeObject(books, Formatting.Indented));
        }
    }
}
