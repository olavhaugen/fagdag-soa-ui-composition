using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Sales;

namespace BookGenerator
{
    internal static class Deserialize
    {
        internal static BookDetails[] Books(string fileName)
        {
            var json = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(fileName));

            return ((IEnumerable<dynamic>)json.editions).Select(x => new BookDetails
            {
                Name = x.title,
                Edition = x.edition_name,
                Tags = Tags(x.subjects),
                Id = Id(x.isbn_13, "ISBN") ?? Id(x.isbn_10, "ISBN") ?? Id(x.lccn, "LCCN") ?? Id(x.oclc_numbers, "OCLC"),
                Author = x.by_statement

            }).Where(x => x.Id != null).ToArray();
        }

        private static string[] Tags(IEnumerable<dynamic> x)
        {
            return x != null ? x.Select(y => (string)y).ToArray() : null;
        }

        private static string Id(IEnumerable<dynamic> x, string prefix)
        {
            return x != null ? string.Format("{0}-{1}", prefix, x.FirstOrDefault()) : null;
        }
    }
}