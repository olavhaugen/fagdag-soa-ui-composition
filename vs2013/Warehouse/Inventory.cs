using System;

namespace Warehouse
{
    public class Inventory
    {
        public string BookId { get; set; }
        public int Stock { get; set; }
        public DateTime? NextExpectedDelivery { get; set; }
    }
}