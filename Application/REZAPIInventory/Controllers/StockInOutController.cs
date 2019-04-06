using REZCores;
using REZRepository;
using REZServices;
using System;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace REZAPIInventory.Controllers
{
   // [Authorize]
    public class StockInOutController : ApiController
    {
        BLStockInOut obj = new BLStockInOut();
        public StockInOutController()
        {
            //var identity = User.Identity as ClaimsIdentity;
            //foreach (var item in identity.Claims)
            //{
            //    if (item.Type == "ConnectionString")
            //    {
            //        Utility.ConnectionString = item.Value;
            //        Utility.ConnectionString = item.Value;
            //    }
            //}

             Utility.ConnectionString = "Data Source=122.160.123.4;Initial Catalog=REZInventory;user id =sa;password=Techryde@2019";
        }
        [HttpGet]
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult GetStockRequest(string Qtype, int In_StoreId, int Out_StoreId, DateTime FromDate, DateTime Todate)
        {
            var list = obj.DisplayStockRequest(Qtype, 0, In_StoreId, Out_StoreId, FromDate, Todate);
            return Ok(list);
        }
        [HttpGet]
        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult GetStockRequestDetail(string Qtype, int StockReqId)
        {
            var list = obj.DisplayStockRequestDetail(Qtype, StockReqId);
            return Ok(list);
        }
        [HttpPost]
        //[ResponseType(typeof(OrderModel))]
        public IHttpActionResult SaveStockRequest(StockInOutModel ob)
        {
            System.Diagnostics.Debugger.Break();
            string str = obj.SaveStockRequest(ob);
            return Ok(str);
        }
        [HttpPost]
        public IHttpActionResult SaveStockRequestItem(SaveInOutItemModel ob)
        {
            string str = obj.SaveStockRequestItem(ob);
            return Ok(str);
        }
        [HttpPost]
        public IHttpActionResult SaveStockTransfer(StockInOutModel ob)
        {
            string str = obj.SaveStockTransfer(ob);
            return Ok(str);
        }
    }
}
