using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZCores
{
    public class StockTakenModel : CommonModel
    {
        public int StockTakingId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime BDate { get; set; }
        public int InventoryTime { get; set; }
        public int Status { get; set; }
        public int StocktakingTypeId { get; set; }
        public string StocktakingType { get; set; }
        public string strCountSheetModel { get; set; }
        public List<CountSheetModel> lstCountSheetModel { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal TheoAmount { get; set; }
        public decimal VarAmount { get; set; }
    }
    public class CountSheetModel
    {
        public int StockTakingId { get; set; }
        public int ItemId { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string UnitName { get; set; }
        public decimal YesterdayActQty { get; set; }
        public decimal SaleQty { get; set; }
        public decimal TheoAmount { get; set; }
        public decimal ActualQty { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal VarQty { get; set; }
        public decimal VarAmount { get; set; }
        public decimal ActualCost { get; set; }
    }
}
