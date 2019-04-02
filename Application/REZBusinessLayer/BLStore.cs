using REZCores;
using REZServices;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace REZRepository
{
  public class BLStore
    {
        DLStore obj = new DLStore();

        public string SaveStore(StoreModel objunit)
        {
            return "";
        }

        public List<StoreModel> DisplayStore(string Qtype, int StoreId,int MasterStoreId)
        {
            List<StoreModel> objlist = new List<StoreModel>();
            var dt = obj.DisplayStore(Qtype, StoreId, MasterStoreId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new StoreModel
                {
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<string>("StoreName"), 
                    Address = x.Field<string>("Address"),
                    City = x.Field<string>("City"),
                    State = x.Field<string>("State"),
                    Email = x.Field<string>("Email"),
                    Phone = x.Field<string>("Phone"),
                    Manager = x.Field<string>("Manager"),
                    IsActive = x.Field<bool>("IsActive")
                }).ToList();
            }
            return objlist;
        }

        public List<StoreModel> DDLStore()
        {
            List<StoreModel> objlist = new List<StoreModel>();
            var dt = obj.DisplayStore("DDL", 0, 0).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new StoreModel
                {
                    StoreId = x.Field<int>("StoreId"),
                    StoreName = x.Field<string>("StoreName")                 
                }).ToList();
            }
            return objlist;
        }

    }
}
