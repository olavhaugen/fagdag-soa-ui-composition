using System.Collections.Generic;
using System.Web.Http;
using Marketing;

namespace Web.Api.Controllers
{
    [RoutePrefix("marketing")]
    public class MarketingController : ApiController
    {
        [Route("bookprices/{id}")]
        public BookPrice GetBookPrice(string id)
        {
            return new BookPriceProvider().FindById(id);
        }

        [Route("imageurls/{id}")]
        public Dictionary<string, string> GetImageUrls(string id)
        {
            var parts = id.Split('-');

            var url = string.Format("http://covers.openlibrary.org/b/{0}/{1}-{{0}}.jpg", parts[0], parts[1]);

            return new Dictionary<string, string>
            {
                {"cover-small", string.Format(url, "S")},
                {"cover-medium", string.Format(url, "M")},
                {"cover-large", string.Format(url, "L")},
            };
        }
    }
}