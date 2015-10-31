using System.Collections.Generic;
using System.Linq;

namespace Shipping
{
    public class ShippingDetailsStore
    {
        private static List<ShippingDetails> _shippingDetails;

        private static IList<ShippingDetails> ShippingDetails
        {
            get
            {
                return _shippingDetails ?? (_shippingDetails = new List<ShippingDetails>());
            }
        }

        public void Add(ShippingDetails d)
        {
            ShippingDetails.Add(d);
        }

        public ShippingDetails FindById(string id)
        {
            return ShippingDetails.FirstOrDefault(x => x.OrderId == id);
        }
    }
}