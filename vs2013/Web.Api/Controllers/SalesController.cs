using System.Collections.Generic;
using System.Web.Http;
using Sales;

namespace Web.Api.Controllers
{
    [RoutePrefix("sales")]
    public class SalesController : ApiController
    {
        [Route("books")]
        public IEnumerable<Book> GetBooks()
        {
            return new BooksProvider().AllBooks();
        }

        [Route("book/{id}")]
        public BookDetails GetBook(string id)
        {
            return new BooksProvider().FindById(id);
        }
    }
}