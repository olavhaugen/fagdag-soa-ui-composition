using System.Web.Http;
using Shipping;

namespace Web.Api.Controllers
{
    [RoutePrefix("shipping")]
    public class ShippingController : ApiController
    {
        ShippingDetailsStore _detailsStore = new ShippingDetailsStore();

        [Route("orders/{id}"), HttpPost]
        public IHttpActionResult PostShippingDetails(string id, string address)
        {
            var d = new ShippingDetails { OrderId = id, Address = address };
            _detailsStore.Add(d);
            return Created("/shipping/orders/" + id, d);
        }
    }
}