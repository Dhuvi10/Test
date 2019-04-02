using REZCores;
using REZServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace REZRepository
{
   public class BLOrder
    {
        DLOrder obj = new DLOrder();
        public string SaveOrder(OrderModel objMedel)
        {
            return obj.SaveOrder(objMedel);
        }
        public string SaveOrderItem(SaveItemModel objMedel)
        {
            return obj.SaveOrderItem(objMedel);
        }
        public string SaveReceiving(OrderModel objMedel)
        {
            return obj.SaveReceiving(objMedel);
        }

        public List<OrderModel> DisplayOrder(string Qtype, int OrderId, int VendorId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            List<OrderModel> objlist = new List<OrderModel>();
            var dt = obj.DisplayOrder(Qtype, OrderId, VendorId, StoreId, FromDate, Todate).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new OrderModel
                {
                    OrderId = x.Field<int>("OrderId"),
                    OrderNo = x.Field<string>("OrderNo"),
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<string>("StoreName"),
                    BDate = x.Field<DateTime>("BDate"),
                    VendorId = x.Field<int>("VendorId"),
                    VendorName = x.Field<string>("VendorName"),
                    Status = x.Field<int>("Status"),
                    TotalAmount = x.Field<string>("TotalAmount"),
                    Reference = x.Field<string>("Reference")                  
                }).ToList();
            }
            return objlist;
        }

        public OrderModel DisplayOrderDetail(string Qtype, int OrderId)
        {
            OrderModel objlist = new OrderModel();
            DataSet ds = obj.DisplayOrder(Qtype, OrderId, 0, 0, DateTime.Now, DateTime.Now);
            if (ds.Tables[0].Rows.Count > 0)
            {
                objlist = ds.Tables[0].AsEnumerable().Select(x => new OrderModel
                {
                    OrderId = x.Field<int>("OrderId"),
                    OrderNo = x.Field<string>("OrderNo"),
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<string>("StoreName"),
                    BDate = x.Field<DateTime>("BDate"),
                    VendorId = x.Field<int>("VendorId"),
                    VendorName = x.Field<string>("VendorName"),
                    Status = x.Field<int>("Status"),
                    Reference = x.Field<string>("Reference"),
                    ReceiptNo = x.Field<string>("ReceiptNo"),
                    CreatedBy = x.Field<string>("CreatedBy"),
                    CreatedOn = x.Field<string>("CreatedOn"),
                    ModifiedBy = x.Field<string>("ModifiedBy"),
                    ModifiedOn = x.Field<string>("ModifiedOn")                   
                }).FirstOrDefault();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                objlist.lstOrderItemModel = ds.Tables[1].AsEnumerable().Select(x => new OrderItemModel
                {
                    OrderId = x.Field<int>("OrderId"),
                    ItemId = x.Field<int>("ItemId"),
                    ItemCode = x.Field<int>("ItemCode"),
                    ItemName = x.Field<string>("ItemName"),
                    Qty = x.Field<decimal>("Qty"),
                    UnitName = x.Field<string>("UnitName"),
                    Price = x.Field<decimal>("Price"),
                    TaxRate = x.Field<decimal>("TaxRate"),
                    NetTotal = x.Field<decimal>("NetTotal"),
                    TotalTax = x.Field<decimal>("TotalTax"),
                    TotalAmount = x.Field<decimal>("TotalAmount")                  
                }).ToList();
            }
            return objlist;
        }   
    }
}
