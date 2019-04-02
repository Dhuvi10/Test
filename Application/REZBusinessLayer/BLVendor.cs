using REZCores;
using REZServices;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace REZRepository
{
    public class BLVendor
    {

        DLVendor obj = new DLVendor();
        public List<VendorModel> DDLVendor()
        {
            List<VendorModel> objlist = new List<VendorModel>();
            var dt = obj.DisplayVendor("DDL", 0, 0).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new VendorModel
                {
                    VendorId = x.Field<int>("VendorId"),
                    VendorName = x.Field<string>("VendorName")
                }).ToList();
            }
            return objlist;
        }


        public List<VendorCatalogModel> GetVendorCatalog(string Qtype, int VendorId, int ItemGroupId)
        {
            List<VendorCatalogModel> objlist = new List<VendorCatalogModel>();
            var dt = obj.DisplayVendor(Qtype, VendorId, ItemGroupId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new VendorCatalogModel
                {
                    ItemId = x.Field<int>("ItemId"),
                    ItemCode = x.Field<int>("ItemCode"),
                    ItemName = x.Field<string>("ItemName"),
                    UnitName = x.Field<string>("UnitName"),
                    FixedorVariable = x.Field<int>("FixedorVariable"),
                    Price = x.Field<decimal>("Price"),
                    TaxRate = x.Field<decimal>("TaxRate")
                }).ToList();
            }
            return objlist;
        }
    }
}
