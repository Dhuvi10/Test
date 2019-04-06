using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZCores
{
   
    public class StockInOutModel : CommonModel
    {
        public int StockReqId { get; set; }
        public string TransferNo { get; set; }
       
        public int In_StoreId { get; set; }
        public string In_Store { get; set; }
        public int Out_StoreId { get; set; }
        public string Out_Store { get; set; }
        public DateTime BDate { get; set; }
        public string Reference { get; set; }
        public int Status { get; set; }
        public string strStockInOutItemModel { get; set; }
        public List<StockInOutItemModel> lstStockInOutItemModel { get; set; }

    }
    public class StockInOutItemModel
    {
        public int StockReqId { get; set; }
        public int ItemId { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string UnitName { get; set; }      
    }

    public class SaveInOutItemModel
    {
        public int StockReqId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string strOrderItemModel { get; set; }


    }



}
