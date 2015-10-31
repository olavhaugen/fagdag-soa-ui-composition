using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Warehouse
{
    public class InventoryProvider
    {
        private static Inventory[] _inventories;

        private static IEnumerable<Inventory> Inventories
        {
            get
            {
                return _inventories ?? (_inventories = JsonConvert.DeserializeObject<Inventory[]>(File.ReadAllText("inventory.json")));
            }
        }

        public Inventory FindById(string id)
        {
            return Inventories.FirstOrDefault(x => x.BookId == id);
        }
    }
}