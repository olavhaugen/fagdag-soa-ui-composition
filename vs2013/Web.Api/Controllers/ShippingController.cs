using System;
using System.Web.Http;
using Shipping;

namespace Web.Api.Controllers
{
    [RoutePrefix("shipping")]
    public class ShippingController : ApiController
    {
        ShippingDetailsStore _detailsStore = new ShippingDetailsStore();

        [Route("shippingdetails/{id}"), HttpPost]
        public ShippingDetails PostShippingDetails(string id, string address)
        {
            var d = new ShippingDetails { OrderId = id, Address = address };
            _detailsStore.Add(d);
            return d; // TODO: return code 201?
        }

        [Route("payments/{id}"), HttpPost]
        public ShippingDetails PostPaymentReceived(string id)
        {
            var sd = _detailsStore.FindById(id);
            Console.WriteLine("Shipping order {0} to {1}", sd.OrderId, sd.Address);
            return sd;
        }
    }
}