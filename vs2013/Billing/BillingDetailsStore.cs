using System.Collections.Generic;
using System.Linq;

namespace Billing
{
    public class BillingDetailsStore
    {
        private static List<BillingDetails> _billingDetails;

        private static IList<BillingDetails> BillingDetails
        {
            get
            {
                return _billingDetails ?? (_billingDetails = new List<BillingDetails>());
            }
        }

        public void Add(BillingDetails d)
        {
            BillingDetails.Add(d);
        }

        public BillingDetails FindById(string id)
        {
            return BillingDetails.FirstOrDefault(x => x.OrderId == id);
        }
    }
}