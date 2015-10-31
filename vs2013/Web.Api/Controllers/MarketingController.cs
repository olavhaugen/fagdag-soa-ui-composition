using System.Web.Http;
using Marketing;

namespace Web.Api.Controllers
{
    [RoutePrefix("marketing")]
    public class MarketingController : ApiController
    {
        [Route("bookprice/{id}")]
        public BookPrice GetBookPrice(string id)
        {
            return new BookPriceProvider().FindById(id);
        }
    }
}