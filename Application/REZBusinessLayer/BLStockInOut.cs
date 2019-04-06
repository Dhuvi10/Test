using REZCores;
using REZServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace REZRepository
{
  public  class BLStockInOut
    {
        DLStockInOut obj = new DLStockInOut();
        public string SaveStockRequest(StockInOutModel objMedel)
        {
            return obj.SaveStockRequest(objMedel);
        }
        public string SaveStockRequestItem(SaveInOutItemModel objMedel)
        {
            return obj.SaveStockRequestItem(objMedel);
        }
        public string SaveStockTransfer(StockInOutModel objMedel)
        {
            return obj.SaveStockTransfer(objMedel);
        }

        public List<StockInOutModel> DisplayStockRequest(string Qtype, int StockReqId, int In_StoreId, int Out_StoreId, DateTime FromDate, DateTime Todate)
        {
           
            List<StockInOutModel> objlist = new List<StockInOutModel>();
            var dt = obj.DisplayStockRequest(Qtype, StockReqId, In_StoreId,  Out_StoreId, FromDate, Todate).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new StockInOutModel
                {
                    StockReqId = x.Field<int>("StockReqId"),
                    TransferNo = x.Field<string>("TransferNo"),
                    In_StoreId = x.Field<int>("In_StoreId"),
                    In_Store = x.Field<string>("In_Store"),
                    BDate = x.Field<DateTime>("BDate"),
                    Out_StoreId = x.Field<int>("Out_StoreId"),
                    Out_Store = x.Field<string>("Out_Store"),
                    Status = x.Field<int>("Status"),
                    Reference = x.Field<string>("Reference")
                }).ToList();
            }
            return objlist;
        }

        public StockInOutModel DisplayStockRequestDetail(string Qtype, int StockReqId)
        {
            StockInOutModel objlist = new StockInOutModel();
            DataSet ds = obj.DisplayStockRequest(Qtype, StockReqId, 0, 0, DateTime.Now, DateTime.Now);
            if (ds.Tables[0].Rows.Count > 0)
            {
                objlist = ds.Tables[0].AsEnumerable().Select(x => new StockInOutModel
                {
                    StockReqId = x.Field<int>("StockReqId"),
                    TransferNo = x.Field<string>("TransferNo"),
                    In_StoreId = x.Field<int>("In_StoreId"),
                    In_Store = x.Field<string>("In_Store"),
                    BDate = x.Field<DateTime>("BDate"),
                    Out_StoreId = x.Field<int>("Out_StoreId"),
                    Out_Store = x.Field<string>("Out_Store"),
                    Status = x.Field<int>("Status"),
                    Reference = x.Field<string>("Reference"),
                    CreatedBy = x.Field<string>("CreatedBy"),
                    CreatedOn = x.Field<string>("CreatedOn"),
                    ModifiedBy = x.Field<string>("ModifiedBy"),
                    ModifiedOn = x.Field<string>("ModifiedOn")
                }).FirstOrDefault();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                objlist.lstStockInOutItemModel = ds.Tables[1].AsEnumerable().Select(x => new StockInOutItemModel
                {
                    StockReqId = x.Field<int>("StockReqId"),
                    ItemId = x.Field<int>("ItemId"),
                    ItemCode = x.Field<int>("ItemCode"),
                    ItemName = x.Field<string>("ItemName"),
                    Qty = x.Field<decimal>("Qty"),
                    UnitName = x.Field<string>("UnitName")                   
                }).ToList();
            }
            return objlist;
        }
    }
}
