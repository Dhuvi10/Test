using REZCores;
using REZRepository;
using REZServices;
using System;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace REZAPIInventory.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        BLOrder obj = new BLOrder();
        public OrderController()
        {
            var identity = User.Identity as ClaimsIdentity;
            foreach (var item in identity.Claims)
            {
                if (item.Type == "ConnectionString")
                {
                    Utility.ConnectionString = item.Value;
                    Utility.ConnectionString = item.Value;
                }
            }

           // Utility.ConnectionString = "Data Source=122.160.123.4;Initial Catalog=REZInventory;user id =sa;password=Techryde@2019";
        }
        [HttpGet]
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult GetOrder(string Qtype,int VendorId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            var list = obj.DisplayOrder(Qtype, 0, VendorId, StoreId, FromDate, Todate);
            return Ok(list);
        }
        [HttpGet]
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult GetOrderDetail(string Qtype, int OrderId)
        {
            var list = obj.DisplayOrderDetail(Qtype, OrderId);
            return Ok(list);
        }
        [HttpPost]
        //[ResponseType(typeof(OrderModel))]
        public IHttpActionResult SaveOrder(OrderModel ob)
        {
            System.Diagnostics.Debugger.Break();
            string str = obj.SaveOrder(ob);
            return Ok(str);
        }
        [HttpPost]
        public IHttpActionResult SaveOrderItem(SaveItemModel ob)
        {
            string str = obj.SaveOrderItem(ob);
            return Ok(str);
        }
        [HttpPost]
        public IHttpActionResult SaveReceiving(OrderModel ob)
        {
            string str = obj.SaveReceiving(ob);
            return Ok(str);
        }
    }
}
