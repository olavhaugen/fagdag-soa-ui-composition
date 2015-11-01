using System;
using System.Web.Http;
using Billing;

namespace Web.Api.SelfHost.Controllers
{
    [RoutePrefix("billing")]
    public class BillingController : ApiController
    {
        BillingDetailsStore _detailsStore = new BillingDetailsStore();
        private Random _random = new Random();

        [Route("orders/{id}"), HttpPost]
        public IHttpActionResult PostBillingDetails(string id, string creditCardNumber)
        {
            if (_random.Next(4) == 0)
            {
                return InternalServerError(new BillingException("No funding."));
            }

            var d = new BillingDetails { OrderId = id, CreditCardNumber = creditCardNumber };
            _detailsStore.Add(d);
            return Created("/billing/orders/" + id, d);
        }

        public class BillingException : Exception
        {
            public BillingException(string m) : base(m)
            {
            }
        }
    }
}