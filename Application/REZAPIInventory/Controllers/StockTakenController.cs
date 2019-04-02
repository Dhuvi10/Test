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
    public class StockTakenController : ApiController
    {

        BLStockTaken obj = new BLStockTaken();

        public StockTakenController()
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
        }

        [ResponseType(typeof(StockTakenModel))]
        public IHttpActionResult GetStockTaken(string Qtype,  int StocktakingTypeId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            var list = obj.DisplayStockTaken(Qtype, 0, StocktakingTypeId, StoreId, FromDate, Todate);
            return Ok(list);
        }
        [ResponseType(typeof(StockTakenModel))]
        public IHttpActionResult GetStockTakenDetail(string Qtype, int StockTakingId)
        {
            var list = obj.DisplayStockTakenDetail(Qtype, StockTakingId);
            return Ok(list);
        }
        [HttpPost]
      //[ResponseType(typeof(StockTakenModel))]
        public IHttpActionResult SaveStockTaken(StockTakenModel ob)
        {
            string str = obj.SaveStockTaken(ob);
            return Ok(str);
        }

        [ResponseType(typeof(StockTakenModel))]
        public IHttpActionResult CheckStockTaken(string Qtype, int StocktakingTypeId, int StoreId, DateTime BDate)
        {
            var list = obj.CheckStockTaken(Qtype, StocktakingTypeId, StoreId, BDate);
            return Ok("");
        }

    }
}
