using System.Web.Http;
using Warehouse;

namespace Web.Api.SelfHost.Controllers
{
    [RoutePrefix("warehouse")]
    public class WarehouseController : ApiController
    {
        [Route("inventory/{id}")]
        public Inventory GetBook(string id)
        {
            return new InventoryProvider().FindById(id);
        }
    }
}