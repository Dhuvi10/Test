using REZCores;
using REZServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZRepository
{
    public class BLStockTaken
    {
        DLStockTaken obj = new DLStockTaken();
        public string SaveStockTaken(StockTakenModel objMedel)
        {
            return obj.SaveStockTaken(objMedel);
        }

        public List<StockTakenModel> DisplayStockTaken(string Qtype, int StockTakingId, int StocktakingTypeId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            List<StockTakenModel> objlist = new List<StockTakenModel>();
            var dt = obj.DisplayStockTaken(Qtype, StockTakingId, StocktakingTypeId, StoreId, FromDate, Todate).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new StockTakenModel
                {
                    StockTakingId = x.Field<int>("StockTakingId"),
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<String>("StoreName"),
                    BDate = x.Field<DateTime>("BDate"),
                    InventoryTime = x.Field<int>("InventoryTime"),
                    Status = x.Field<int>("Status"),
                    StocktakingTypeId = x.Field<int>("StocktakingTypeId"),
                    StocktakingType = x.Field<string>("StocktakingType"),
                    ActualAmount = x.Field<decimal>("ActualAmount"),
                    TheoAmount = x.Field<decimal>("TheoAmount"),
                    VarAmount = x.Field<decimal>("VarAmount")
                }).ToList();
            }
            return objlist;
        }


        public StockTakenModel DisplayStockTakenDetail(string Qtype, int StockTakingId)
        {
            StockTakenModel objlist = new StockTakenModel();
            DataSet ds = obj.DisplayStockTaken(Qtype, StockTakingId, 0, 0, DateTime.Now, DateTime.Now);
            if (ds.Tables[0].Rows.Count > 0)
            {
                objlist = ds.Tables[0].AsEnumerable().Select(x => new StockTakenModel
                {
                    StockTakingId = x.Field<int>("StockTakingId"),
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<String>("StoreName"),
                    BDate = x.Field<DateTime>("BDate"),
                    InventoryTime = x.Field<int>("InventoryTime"),
                    Status = x.Field<int>("Status"),
                    StocktakingTypeId = x.Field<int>("StocktakingTypeId"),
                    StocktakingType = x.Field<string>("StocktakingType"),
                    ActualAmount = x.Field<decimal>("ActualAmount"),
                    TheoAmount = x.Field<decimal>("TheoAmount"),
                    VarAmount = x.Field<decimal>("VarAmount"),
                    CreatedBy = x.Field<string>("CreatedBy"),
                    CreatedOn = x.Field<string>("CreatedOn"),
                    ModifiedBy = x.Field<string>("ModifiedBy"),
                    ModifiedOn = x.Field<string>("ModifiedOn")
                }).FirstOrDefault();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                objlist.lstCountSheetModel = ds.Tables[1].AsEnumerable().Select(x => new CountSheetModel
                {

                     StockTakingId= x.Field<int>("StockTakingId"),
                    ItemId = x.Field<int>("ItemId"),
                    ItemCode = x.Field<int>("ItemCode"),
                    ItemName = x.Field<string>("ItemName"),
                    Qty = x.Field<decimal>("Qty"),
                    UnitName = x.Field<string>("UnitName"),
                    YesterdayActQty = x.Field<decimal>("YesterdayActQty"),
                    SaleQty = x.Field<decimal>("SaleQty"),
                    TheoAmount = x.Field<decimal>("TheoAmount"),
                    ActualQty = x.Field<decimal>("ActualQty"),
                    ActualAmount = x.Field<decimal>("ActualAmount"),
                    VarQty = x.Field<decimal>("VarQty"),
                    VarAmount = x.Field<decimal>("VarAmount"),
                    ActualCost = x.Field<decimal>("ActualCost")
                }).ToList();
            }
            return objlist;
        }

        public List<StockTakenModel> CheckStockTaken(string Qtype, int StocktakingTypeId, int StoreId, DateTime BDate)
        {
            List<StockTakenModel> objlist = new List<StockTakenModel>();
            var dt = obj.DisplayStockTaken(Qtype, 0, StocktakingTypeId, StoreId, BDate, DateTime.Now).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new StockTakenModel
                {
                    StockTakingId = x.Field<int>("StockTakingId"),
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<String>("StoreName"),
                    BDate = x.Field<DateTime>("BDate"),
                    InventoryTime = x.Field<int>("InventoryTime"),
                    Status = x.Field<int>("Status"),
                    StocktakingTypeId = x.Field<int>("StocktakingTypeId"),
                    StocktakingType = x.Field<string>("StocktakingType")
                }).ToList();
            }
            return objlist;
        }


    }
}
