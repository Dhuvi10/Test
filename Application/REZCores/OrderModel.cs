using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZCores
{
   public class OrderModel : CommonModel
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string ReceiptNo { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime BDate { get; set; }
        public string Reference { get; set; }
        public int Status { get; set; }
        public string TotalAmount { get; set; }
        public string strOrderItemModel { get; set; }
        public List<OrderItemModel> lstOrderItemModel { get; set; }
   
    }
    public class OrderItemModel
    {      
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal NetTotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class SaveItemModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string strOrderItemModel { get; set; }


    }

}
