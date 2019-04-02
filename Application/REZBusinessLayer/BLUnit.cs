using REZCores;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using REZServices;

namespace REZRepository
{
    public class BLUnit
    {
        DLUnit obj = new DLUnit();
        public string SaveUnitMaster(UnitModel objunit)
        {
            return obj.SaveUnitMaster(objunit);
        }

        public List<UnitModel> DisplayUnitMaster(string Qtype, int UnitId)
        {
            List<UnitModel> objlist = new List<UnitModel>();
            var dt = obj.DisplayUnitMaster(Qtype, UnitId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new UnitModel
                {
                    UnitId = x.Field<int>("UnitId"),
                    UnitName = x.Field<string>("UnitName"),
                    IsActive = x.Field<bool>("IsActive")
                }).ToList();
            }
            return objlist;
        }        

    }
}
