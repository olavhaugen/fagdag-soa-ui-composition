using System.Web.Http;
using Billing;

namespace Web.Api.Controllers
{
    [RoutePrefix("billing")]
    public class BillingController : ApiController
    {
        BillingDetailsStore _detailsStore = new BillingDetailsStore();

        [Route("orders/{id}"), HttpPost]
        public IHttpActionResult PostBillingDetails(string id, string creditCardNumber)
        {
            var d = new BillingDetails { OrderId = id, CreditCardNumber = creditCardNumber};
            _detailsStore.Add(d);
            return Created("/billing/orders/" + id, d);
        }
    }
}